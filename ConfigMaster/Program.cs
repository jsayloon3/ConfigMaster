using ConfigMaster.BLL.Cache;
using ConfigMaster.BLL.Services;
using ConfigMaster.BLL.Session;
using ConfigMaster.DAL;
using ConfigMaster.DAL.Profiles;
using ConfigMaster.DAL.Repositories;
using ConfigMaster.Defaults;
using ConfigMaster.Modals;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ConfigMaster
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static IConfiguration? Configuration { get; private set; }
        public static string _filePath = string.Empty;
        private static string _localConfiguration = string.Empty;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, "ConfigMaster"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Another instance of ConfigMaster is already running.", "ConfigMaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    MainAsync(args).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "An unhandled exception occurred during application execution.");
                    MessageBox.Show("An unexpected error occurred. Please check the logs for more details.", "ConfigMaster", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
        }

        static async Task MainAsync(string[] args)
        {
            string applicationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ConfigMaster");
            if (!Directory.Exists(applicationPath)) Directory.CreateDirectory(applicationPath);
            string dbFile = Path.Combine(applicationPath, "configmaster.db");

            // Tool configurations
            _localConfiguration = Path.Combine(applicationPath, "LocalConfiguration");
            if (!Directory.Exists(_localConfiguration)) Directory.CreateDirectory(_localConfiguration);

            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                        {"ConnectionStrings:SQLite", $"Data Source={dbFile}"}
                })
                .Build();

            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    Path.Combine(AppContext.BaseDirectory, "logs", "applicationlog.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 15
                )
                .CreateLogger();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateBuilder().Build();
            ServiceProvider = host.Services;

            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                var config = scope.ServiceProvider.GetRequiredService<AddDefaultConfigurationPath>();
                if (config.IsPathEmpty().Result) await config.AddDefaultPath();

                var loginUsers = scope.ServiceProvider.GetRequiredService<AddDefaultUsers>();
                if (!loginUsers.HasUser().Result) await loginUsers.Register();

                if (args.Length > 0)
                { 
                    string filePathOpen = args[0];
                    var updatePath = scope.ServiceProvider.GetRequiredService<IPathManagerService>();
                    await updatePath.UpdatePath(filePathOpen);
                }
            }

            Application.Run(ServiceProvider.GetRequiredService<AuthForm>());
        }

        static IHostBuilder CreateBuilder()
        {
            return Host.CreateDefaultBuilder()
                .UseSerilog() // Use Serilog for logging
                .ConfigureServices((context, services) =>
                {
                    // Add Configuration
                    services.AddSingleton<IConfiguration>(Configuration);

                    // Add Database
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlite(Configuration.GetConnectionString("SQLite"));
                    });

                    // Add Repositories
                    services.AddScoped<IPathManagerRepository, PathManagerRepository>();
                    services.AddScoped<IIniFileRepository, IniFileRepository>();
                    services.AddScoped<IAuditTrailManagerRepository, AuditTrailManagerRepository>();
                    services.AddScoped<IUserRepository, UserRepository>();

                    // Add Services
                    services.AddScoped<IIniFileService, IniFileService>();
                    services.AddScoped<IPathManagerService, PathManagerService>();
                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<IUserManagerService, UserManagerService>();
                    services.AddScoped<IAuditTrailManagerService, AuditTrailManagerService>();

                    // Add Defaults
                    services.AddScoped<AddDefaultConfigurationPath>();
                    services.AddScoped<AddDefaultUsers>();

                    // Add SessionManager
                    services.AddSingleton<SessionManager>();
                    services.AddSingleton<ILocalConfigurationPath>(provider => new LocalConfigurationPath(_localConfiguration));

                    // Add Forms
                    services.AddTransient<MainForm>();
                    services.AddTransient<AuthForm>();
                    services.AddTransient<EditConfigurationModal>();
                    services.AddTransient<ExportAuditLogModal>();
                    services.AddTransient<ConfigureReadOnlySettingsModal>();

                    // Add AutoMapper
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                });
        }
    }
}
