namespace ConfigMaster.Modals
{
    partial class EditConfigurationModal
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
            HeaderPanel = new Panel();
            HeaderPanel_TitleArea = new Panel();
            TitleLabel = new Label();
            HeaderDividerPanel = new Panel();
            HeaderDivider = new Label();
            FooterPanel = new Panel();
            panel9 = new Panel();
            panel11 = new Panel();
            CancelButton = new MaterialSkin.Controls.MaterialButton();
            panel10 = new Panel();
            SaveButton = new MaterialSkin.Controls.MaterialButton();
            FooterDividerPanel = new Panel();
            FooterDivider = new Label();
            BodyPanel = new Panel();
            panel6 = new Panel();
            SettingValueTextBox = new TextBox();
            panel7 = new Panel();
            SettingValueRequiredLabel = new Label();
            panel8 = new Panel();
            label6 = new Label();
            panel2 = new Panel();
            SettingNameTextBox = new TextBox();
            panel4 = new Panel();
            SettingNameRequiredLabel = new Label();
            panel5 = new Panel();
            label4 = new Label();
            BodyPanel_SectionArea = new Panel();
            SectionComboBox = new ComboBox();
            panel3 = new Panel();
            SectionRequiredLabel = new Label();
            panel1 = new Panel();
            label1 = new Label();
            HeaderPanel.SuspendLayout();
            HeaderPanel_TitleArea.SuspendLayout();
            HeaderDividerPanel.SuspendLayout();
            FooterPanel.SuspendLayout();
            panel9.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            FooterDividerPanel.SuspendLayout();
            BodyPanel.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            BodyPanel_SectionArea.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(HeaderPanel_TitleArea);
            HeaderPanel.Controls.Add(HeaderDividerPanel);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(802, 56);
            HeaderPanel.TabIndex = 0;
            // 
            // HeaderPanel_TitleArea
            // 
            HeaderPanel_TitleArea.Controls.Add(TitleLabel);
            HeaderPanel_TitleArea.Dock = DockStyle.Bottom;
            HeaderPanel_TitleArea.Location = new Point(0, 0);
            HeaderPanel_TitleArea.Name = "HeaderPanel_TitleArea";
            HeaderPanel_TitleArea.Padding = new Padding(10);
            HeaderPanel_TitleArea.Size = new Size(802, 54);
            HeaderPanel_TitleArea.TabIndex = 1;
            // 
            // TitleLabel
            // 
            TitleLabel.Dock = DockStyle.Top;
            TitleLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(10, 10);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(782, 31);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Title";
            // 
            // HeaderDividerPanel
            // 
            HeaderDividerPanel.Controls.Add(HeaderDivider);
            HeaderDividerPanel.Dock = DockStyle.Bottom;
            HeaderDividerPanel.Location = new Point(0, 54);
            HeaderDividerPanel.Name = "HeaderDividerPanel";
            HeaderDividerPanel.Size = new Size(802, 2);
            HeaderDividerPanel.TabIndex = 0;
            // 
            // HeaderDivider
            // 
            HeaderDivider.BorderStyle = BorderStyle.Fixed3D;
            HeaderDivider.Dock = DockStyle.Fill;
            HeaderDivider.Location = new Point(0, 0);
            HeaderDivider.Name = "HeaderDivider";
            HeaderDivider.Size = new Size(802, 2);
            HeaderDivider.TabIndex = 0;
            // 
            // FooterPanel
            // 
            FooterPanel.Controls.Add(panel9);
            FooterPanel.Controls.Add(FooterDividerPanel);
            FooterPanel.Dock = DockStyle.Bottom;
            FooterPanel.Location = new Point(0, 370);
            FooterPanel.Name = "FooterPanel";
            FooterPanel.Size = new Size(802, 76);
            FooterPanel.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(panel11);
            panel9.Controls.Add(panel10);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 2);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(10);
            panel9.Size = new Size(802, 74);
            panel9.TabIndex = 1;
            // 
            // panel11
            // 
            panel11.Controls.Add(CancelButton);
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(508, 10);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(3);
            panel11.Size = new Size(142, 54);
            panel11.TabIndex = 0;
            // 
            // CancelButton
            // 
            CancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            CancelButton.Depth = 0;
            CancelButton.Dock = DockStyle.Fill;
            CancelButton.HighEmphasis = true;
            CancelButton.Icon = null;
            CancelButton.Location = new Point(3, 3);
            CancelButton.Margin = new Padding(4, 6, 4, 6);
            CancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            CancelButton.Name = "CancelButton";
            CancelButton.NoAccentTextColor = Color.Empty;
            CancelButton.Size = new Size(136, 48);
            CancelButton.TabIndex = 20;
            CancelButton.Text = "Cancel";
            CancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            CancelButton.UseAccentColor = false;
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // panel10
            // 
            panel10.Controls.Add(SaveButton);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(650, 10);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(3);
            panel10.Size = new Size(142, 54);
            panel10.TabIndex = 0;
            // 
            // SaveButton
            // 
            SaveButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            SaveButton.Depth = 0;
            SaveButton.Dock = DockStyle.Fill;
            SaveButton.HighEmphasis = true;
            SaveButton.Icon = null;
            SaveButton.Location = new Point(3, 3);
            SaveButton.Margin = new Padding(4, 6, 4, 6);
            SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            SaveButton.Name = "SaveButton";
            SaveButton.NoAccentTextColor = Color.Empty;
            SaveButton.Size = new Size(136, 48);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Save";
            SaveButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            SaveButton.UseAccentColor = false;
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // FooterDividerPanel
            // 
            FooterDividerPanel.Controls.Add(FooterDivider);
            FooterDividerPanel.Dock = DockStyle.Top;
            FooterDividerPanel.Location = new Point(0, 0);
            FooterDividerPanel.Name = "FooterDividerPanel";
            FooterDividerPanel.Size = new Size(802, 2);
            FooterDividerPanel.TabIndex = 0;
            // 
            // FooterDivider
            // 
            FooterDivider.BorderStyle = BorderStyle.Fixed3D;
            FooterDivider.Dock = DockStyle.Fill;
            FooterDivider.Location = new Point(0, 0);
            FooterDivider.Name = "FooterDivider";
            FooterDivider.Size = new Size(802, 2);
            FooterDivider.TabIndex = 0;
            // 
            // BodyPanel
            // 
            BodyPanel.Controls.Add(panel6);
            BodyPanel.Controls.Add(panel2);
            BodyPanel.Controls.Add(BodyPanel_SectionArea);
            BodyPanel.Dock = DockStyle.Fill;
            BodyPanel.Location = new Point(0, 56);
            BodyPanel.Name = "BodyPanel";
            BodyPanel.Size = new Size(802, 314);
            BodyPanel.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(SettingValueTextBox);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 208);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(10);
            panel6.Size = new Size(802, 104);
            panel6.TabIndex = 5;
            // 
            // SettingValueTextBox
            // 
            SettingValueTextBox.Dock = DockStyle.Fill;
            SettingValueTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SettingValueTextBox.Location = new Point(10, 40);
            SettingValueTextBox.Name = "SettingValueTextBox";
            SettingValueTextBox.Size = new Size(782, 30);
            SettingValueTextBox.TabIndex = 3;
            SettingValueTextBox.TextChanged += SettingValueTextBox_TextChanged;
            // 
            // panel7
            // 
            panel7.Controls.Add(SettingValueRequiredLabel);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(10, 72);
            panel7.Name = "panel7";
            panel7.Size = new Size(782, 22);
            panel7.TabIndex = 2;
            // 
            // SettingValueRequiredLabel
            // 
            SettingValueRequiredLabel.Dock = DockStyle.Fill;
            SettingValueRequiredLabel.ForeColor = Color.Red;
            SettingValueRequiredLabel.Location = new Point(0, 0);
            SettingValueRequiredLabel.Name = "SettingValueRequiredLabel";
            SettingValueRequiredLabel.Size = new Size(782, 22);
            SettingValueRequiredLabel.TabIndex = 0;
            SettingValueRequiredLabel.Text = "Required";
            // 
            // panel8
            // 
            panel8.Controls.Add(label6);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(10, 10);
            panel8.Name = "panel8";
            panel8.Size = new Size(782, 30);
            panel8.TabIndex = 0;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(782, 30);
            label6.TabIndex = 0;
            label6.Text = "Setting Value";
            // 
            // panel2
            // 
            panel2.Controls.Add(SettingNameTextBox);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 104);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(802, 104);
            panel2.TabIndex = 4;
            // 
            // SettingNameTextBox
            // 
            SettingNameTextBox.Dock = DockStyle.Fill;
            SettingNameTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SettingNameTextBox.Location = new Point(10, 40);
            SettingNameTextBox.Name = "SettingNameTextBox";
            SettingNameTextBox.Size = new Size(782, 30);
            SettingNameTextBox.TabIndex = 3;
            SettingNameTextBox.TextChanged += SettingNameTextBox_TextChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(SettingNameRequiredLabel);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(10, 72);
            panel4.Name = "panel4";
            panel4.Size = new Size(782, 22);
            panel4.TabIndex = 2;
            // 
            // SettingNameRequiredLabel
            // 
            SettingNameRequiredLabel.Dock = DockStyle.Fill;
            SettingNameRequiredLabel.ForeColor = Color.Red;
            SettingNameRequiredLabel.Location = new Point(0, 0);
            SettingNameRequiredLabel.Name = "SettingNameRequiredLabel";
            SettingNameRequiredLabel.Size = new Size(782, 22);
            SettingNameRequiredLabel.TabIndex = 0;
            SettingNameRequiredLabel.Text = "Required";
            // 
            // panel5
            // 
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(10, 10);
            panel5.Name = "panel5";
            panel5.Size = new Size(782, 30);
            panel5.TabIndex = 0;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(782, 30);
            label4.TabIndex = 0;
            label4.Text = "Setting Name";
            // 
            // BodyPanel_SectionArea
            // 
            BodyPanel_SectionArea.Controls.Add(SectionComboBox);
            BodyPanel_SectionArea.Controls.Add(panel3);
            BodyPanel_SectionArea.Controls.Add(panel1);
            BodyPanel_SectionArea.Dock = DockStyle.Top;
            BodyPanel_SectionArea.Location = new Point(0, 0);
            BodyPanel_SectionArea.Name = "BodyPanel_SectionArea";
            BodyPanel_SectionArea.Padding = new Padding(10);
            BodyPanel_SectionArea.Size = new Size(802, 104);
            BodyPanel_SectionArea.TabIndex = 0;
            // 
            // SectionComboBox
            // 
            SectionComboBox.Dock = DockStyle.Fill;
            SectionComboBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SectionComboBox.FormattingEnabled = true;
            SectionComboBox.Location = new Point(10, 40);
            SectionComboBox.Name = "SectionComboBox";
            SectionComboBox.Size = new Size(782, 31);
            SectionComboBox.TabIndex = 3;
            SectionComboBox.SelectedIndexChanged += SectionComboBox_SelectedIndexChanged;
            SectionComboBox.TextChanged += SectionComboBox_TextChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(SectionRequiredLabel);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(10, 72);
            panel3.Name = "panel3";
            panel3.Size = new Size(782, 22);
            panel3.TabIndex = 2;
            // 
            // SectionRequiredLabel
            // 
            SectionRequiredLabel.Dock = DockStyle.Fill;
            SectionRequiredLabel.ForeColor = Color.Red;
            SectionRequiredLabel.Location = new Point(0, 0);
            SectionRequiredLabel.Name = "SectionRequiredLabel";
            SectionRequiredLabel.Size = new Size(782, 22);
            SectionRequiredLabel.TabIndex = 0;
            SectionRequiredLabel.Text = "Required";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(782, 30);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(782, 30);
            label1.TabIndex = 0;
            label1.Text = "Section";
            // 
            // EditConfigurationModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 446);
            ControlBox = false;
            Controls.Add(BodyPanel);
            Controls.Add(FooterPanel);
            Controls.Add(HeaderPanel);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(1500, 464);
            MinimizeBox = false;
            MinimumSize = new Size(820, 464);
            Name = "EditConfigurationModal";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += EditConfigurationModal_Load;
            HeaderPanel.ResumeLayout(false);
            HeaderPanel_TitleArea.ResumeLayout(false);
            HeaderDividerPanel.ResumeLayout(false);
            FooterPanel.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            FooterDividerPanel.ResumeLayout(false);
            BodyPanel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            BodyPanel_SectionArea.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel HeaderPanel;
        private Panel HeaderDividerPanel;
        private Panel FooterPanel;
        private Panel BodyPanel;
        private Label HeaderDivider;
        private Panel FooterDividerPanel;
        private Label FooterDivider;
        private Panel BodyPanel_SectionArea;
        private Panel HeaderPanel_TitleArea;
        private Label TitleLabel;
        private Panel panel3;
        private Panel panel1;
        private Label label1;
        private Label SectionRequiredLabel;
        private Panel panel6;
        private TextBox SettingValueTextBox;
        private Panel panel7;
        private Label SettingValueRequiredLabel;
        private Panel panel8;
        private Label label6;
        private Panel panel2;
        private TextBox SettingNameTextBox;
        private Panel panel4;
        private Label SettingNameRequiredLabel;
        private Panel panel5;
        private Label label4;
        private Panel panel9;
        private Panel panel11;
        private Panel panel10;
        private MaterialSkin.Controls.MaterialButton CancelButton;
        private MaterialSkin.Controls.MaterialButton SaveButton;
        private ComboBox SectionComboBox;
    }
}