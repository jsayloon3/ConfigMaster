using ConfigMaster.BLL.Services;
using ConfigMaster.DAL;
using ConfigMaster.DAL.Repositories;
using ConfigMaster.Defaults;
using ConfigMaster.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.X509Certificates;

namespace ConfigMaster
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static IConfiguration? Configuration { get; private set; }
        public static string _filePath = string.Empty;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        { 
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ConfigMaster");
            if (!Directory.Exists(dbPath)) Directory.CreateDirectory(dbPath);
            string dbFile = Path.Combine(dbPath, "configmaster.db");

            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    {"ConnectionStrings:SQLite", $"Data Source={dbFile}"}
                })
                .Build();

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
            }
                
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        static IHostBuilder CreateBuilder()
        {
            return Host.CreateDefaultBuilder()
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

                    // Add Services
                    services.AddScoped<IIniFileService, IniFileService>();
                    services.AddScoped<IPathManagerService, PathManagerService>();

                    // Add Defaults
                    services.AddScoped<AddDefaultConfigurationPath>();

                    // Add Forms
                    services.AddTransient<MainForm>();
                    services.AddTransient<EditConfigurationModal>();
                });
        }
    }
}