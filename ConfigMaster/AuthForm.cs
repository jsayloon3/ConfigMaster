using ConfigMaster.BLL.Services;
using ConfigMaster.BLL.Session;
using ConfigMaster.Common.Enums;
using ConfigMaster.ControlConfigurations;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigMaster
{
    public partial class AuthForm : MaterialForm
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly IAuditTrailManagerService _auditTrailManagerService;
        private readonly SessionManager _sessionManager;

        public AuthForm(IServiceProvider serviceProvider, IAuthService authService, IAuditTrailManagerService auditTrailManagerService, SessionManager sessionManager)
        {
            InitializeComponent();
            InitializeMaterialSkin();
            EnableDoubleBuffering();

            _serviceProvider = serviceProvider;
            _authService = authService;
            _auditTrailManagerService = auditTrailManagerService;
            _sessionManager = sessionManager;
        }

        private void InitializeMaterialSkin()
        {
            MaterialSkinTheme materialSkin = new MaterialSkinTheme(this);
            materialSkin.SetTheme();
        }

        private void EnableDoubleBuffering()
        {
            DoubleBuffering doubleBuffering = new DoubleBuffering(this);
            doubleBuffering.EnableDoubleBuffering();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            LoginLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutDown();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            bool isAutheticated = await _authService.ValidateUser(username, password);
            if (isAutheticated)
            {
                var userSession = _sessionManager.CreateSession(username);
                await _auditTrailManagerService.AddLog(message: "Login successful", AuditTrail.ActionType.Login, status: "Success");
                Hide();
                LauncApp();
            }
            else
            {
                MessageBox.Show("Invalid credentials, please try again.", "Invalid credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UsernameTextBox.ResetText();
                PasswordTextBox.ResetText();
                UsernameTextBox.Focus();
            }
        }

        private void LauncApp()
        {
            using var app = _serviceProvider.GetRequiredService<MainForm>();
            app.FormClosing += (s, args) => ShutDown();
            app.ShowDialog();
        }

        private void ShutDown()
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
