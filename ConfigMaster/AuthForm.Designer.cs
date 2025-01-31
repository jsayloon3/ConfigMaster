namespace ConfigMaster
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            LoginButton = new MaterialSkin.Controls.MaterialButton();
            PasswordTextBox = new MaterialSkin.Controls.MaterialTextBox();
            UsernameTextBox = new MaterialSkin.Controls.MaterialTextBox();
            LoginLabel = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(835, 490);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Center;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(448, 490);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(LoginButton);
            panel3.Controls.Add(PasswordTextBox);
            panel3.Controls.Add(UsernameTextBox);
            panel3.Controls.Add(LoginLabel);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(448, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(387, 490);
            panel3.TabIndex = 1;
            // 
            // LoginButton
            // 
            LoginButton.AutoSize = false;
            LoginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LoginButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            LoginButton.Depth = 0;
            LoginButton.HighEmphasis = true;
            LoginButton.Icon = null;
            LoginButton.Location = new Point(32, 304);
            LoginButton.Margin = new Padding(4, 6, 4, 6);
            LoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            LoginButton.Name = "LoginButton";
            LoginButton.NoAccentTextColor = Color.Empty;
            LoginButton.Size = new Size(320, 48);
            LoginButton.TabIndex = 3;
            LoginButton.Text = "Login";
            LoginButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            LoginButton.UseAccentColor = false;
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            LoginButton.Enter += LoginButton_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.AnimateReadOnly = false;
            PasswordTextBox.BorderStyle = BorderStyle.None;
            PasswordTextBox.Depth = 0;
            PasswordTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            PasswordTextBox.Hint = "Password";
            PasswordTextBox.LeadingIcon = null;
            PasswordTextBox.Location = new Point(32, 232);
            PasswordTextBox.MaxLength = 50;
            PasswordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            PasswordTextBox.Multiline = false;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Password = true;
            PasswordTextBox.Size = new Size(320, 50);
            PasswordTextBox.TabIndex = 2;
            PasswordTextBox.Text = "";
            PasswordTextBox.TrailingIcon = null;
            PasswordTextBox.UseAccent = false;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.AnimateReadOnly = false;
            UsernameTextBox.BorderStyle = BorderStyle.None;
            UsernameTextBox.Depth = 0;
            UsernameTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            UsernameTextBox.Hint = "Username";
            UsernameTextBox.LeadingIcon = null;
            UsernameTextBox.Location = new Point(32, 160);
            UsernameTextBox.MaxLength = 50;
            UsernameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            UsernameTextBox.Multiline = false;
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(320, 50);
            UsernameTextBox.TabIndex = 1;
            UsernameTextBox.Text = "";
            UsernameTextBox.TrailingIcon = null;
            UsernameTextBox.UseAccent = false;
            // 
            // LoginLabel
            // 
            LoginLabel.AutoSize = true;
            LoginLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginLabel.Location = new Point(24, 88);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(110, 46);
            LoginLabel.TabIndex = 0;
            LoginLabel.Text = "Login";
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(835, 514);
            Controls.Add(panel1);
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AuthForm";
            Padding = new Padding(0, 24, 0, 0);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AuthForm_FormClosing;
            Load += AuthForm_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private MaterialSkin.Controls.MaterialButton LoginButton;
        private MaterialSkin.Controls.MaterialTextBox PasswordTextBox;
        private MaterialSkin.Controls.MaterialTextBox UsernameTextBox;
        private Label LoginLabel;
    }
}