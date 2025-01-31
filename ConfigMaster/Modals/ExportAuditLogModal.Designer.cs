namespace ConfigMaster.Modals
{
    partial class ExportAuditLogModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportAuditLogModal));
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
            ExportButton = new MaterialSkin.Controls.MaterialButton();
            FooterDividerPanel = new Panel();
            FooterDivider = new Label();
            BodyPanel = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel12 = new Panel();
            panel13 = new Panel();
            panel14 = new Panel();
            PageLabel = new Label();
            label3 = new Label();
            panel15 = new Panel();
            PreviousButton = new Button();
            panel16 = new Panel();
            NextButton = new Button();
            AuditLogDataGridView = new DataGridView();
            BodyPanel_HeaderArea = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            AuditLogSearchTextBox = new MaterialSkin.Controls.MaterialTextBox();
            ExportAuditLogs = new SaveFileDialog();
            panel3 = new Panel();
            HeaderPanel.SuspendLayout();
            HeaderPanel_TitleArea.SuspendLayout();
            HeaderDividerPanel.SuspendLayout();
            FooterPanel.SuspendLayout();
            panel9.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            FooterDividerPanel.SuspendLayout();
            BodyPanel.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel15.SuspendLayout();
            panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AuditLogDataGridView).BeginInit();
            BodyPanel_HeaderArea.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(HeaderPanel_TitleArea);
            HeaderPanel.Controls.Add(HeaderDividerPanel);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(971, 56);
            HeaderPanel.TabIndex = 0;
            // 
            // HeaderPanel_TitleArea
            // 
            HeaderPanel_TitleArea.Controls.Add(TitleLabel);
            HeaderPanel_TitleArea.Dock = DockStyle.Bottom;
            HeaderPanel_TitleArea.Location = new Point(0, 0);
            HeaderPanel_TitleArea.Name = "HeaderPanel_TitleArea";
            HeaderPanel_TitleArea.Padding = new Padding(10);
            HeaderPanel_TitleArea.Size = new Size(971, 54);
            HeaderPanel_TitleArea.TabIndex = 1;
            // 
            // TitleLabel
            // 
            TitleLabel.Dock = DockStyle.Top;
            TitleLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(10, 10);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(951, 31);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Title";
            // 
            // HeaderDividerPanel
            // 
            HeaderDividerPanel.Controls.Add(HeaderDivider);
            HeaderDividerPanel.Dock = DockStyle.Bottom;
            HeaderDividerPanel.Location = new Point(0, 54);
            HeaderDividerPanel.Name = "HeaderDividerPanel";
            HeaderDividerPanel.Size = new Size(971, 2);
            HeaderDividerPanel.TabIndex = 0;
            // 
            // HeaderDivider
            // 
            HeaderDivider.BorderStyle = BorderStyle.Fixed3D;
            HeaderDivider.Dock = DockStyle.Fill;
            HeaderDivider.Location = new Point(0, 0);
            HeaderDivider.Name = "HeaderDivider";
            HeaderDivider.Size = new Size(971, 2);
            HeaderDivider.TabIndex = 0;
            // 
            // FooterPanel
            // 
            FooterPanel.Controls.Add(panel9);
            FooterPanel.Controls.Add(FooterDividerPanel);
            FooterPanel.Dock = DockStyle.Bottom;
            FooterPanel.Location = new Point(0, 571);
            FooterPanel.Name = "FooterPanel";
            FooterPanel.Size = new Size(971, 76);
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
            panel9.Size = new Size(971, 74);
            panel9.TabIndex = 1;
            // 
            // panel11
            // 
            panel11.Controls.Add(CancelButton);
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(677, 10);
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
            panel10.Controls.Add(ExportButton);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(819, 10);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(3);
            panel10.Size = new Size(142, 54);
            panel10.TabIndex = 0;
            // 
            // ExportButton
            // 
            ExportButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ExportButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ExportButton.Depth = 0;
            ExportButton.Dock = DockStyle.Fill;
            ExportButton.HighEmphasis = true;
            ExportButton.Icon = null;
            ExportButton.Location = new Point(3, 3);
            ExportButton.Margin = new Padding(4, 6, 4, 6);
            ExportButton.MouseState = MaterialSkin.MouseState.HOVER;
            ExportButton.Name = "ExportButton";
            ExportButton.NoAccentTextColor = Color.Empty;
            ExportButton.Size = new Size(136, 48);
            ExportButton.TabIndex = 4;
            ExportButton.Text = "Export";
            ExportButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ExportButton.UseAccentColor = false;
            ExportButton.UseVisualStyleBackColor = true;
            ExportButton.Click += ExportButton_Click;
            // 
            // FooterDividerPanel
            // 
            FooterDividerPanel.Controls.Add(FooterDivider);
            FooterDividerPanel.Dock = DockStyle.Top;
            FooterDividerPanel.Location = new Point(0, 0);
            FooterDividerPanel.Name = "FooterDividerPanel";
            FooterDividerPanel.Size = new Size(971, 2);
            FooterDividerPanel.TabIndex = 0;
            // 
            // FooterDivider
            // 
            FooterDivider.BorderStyle = BorderStyle.Fixed3D;
            FooterDivider.Dock = DockStyle.Fill;
            FooterDivider.Location = new Point(0, 0);
            FooterDivider.Name = "FooterDivider";
            FooterDivider.Size = new Size(971, 2);
            FooterDivider.TabIndex = 0;
            // 
            // BodyPanel
            // 
            BodyPanel.Controls.Add(panel3);
            BodyPanel.Controls.Add(panel7);
            BodyPanel.Controls.Add(BodyPanel_HeaderArea);
            BodyPanel.Dock = DockStyle.Fill;
            BodyPanel.Location = new Point(0, 56);
            BodyPanel.Name = "BodyPanel";
            BodyPanel.Padding = new Padding(3);
            BodyPanel.Size = new Size(971, 515);
            BodyPanel.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(3, 456);
            panel7.Name = "panel7";
            panel7.Size = new Size(965, 56);
            panel7.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel12);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(3);
            panel8.Size = new Size(965, 56);
            panel8.TabIndex = 1;
            // 
            // panel12
            // 
            panel12.Controls.Add(panel13);
            panel12.Controls.Add(panel16);
            panel12.Dock = DockStyle.Left;
            panel12.Location = new Point(3, 3);
            panel12.Name = "panel12";
            panel12.Size = new Size(421, 50);
            panel12.TabIndex = 1;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel14);
            panel13.Controls.Add(panel15);
            panel13.Dock = DockStyle.Right;
            panel13.Location = new Point(120, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(301, 50);
            panel13.TabIndex = 1;
            // 
            // panel14
            // 
            panel14.Controls.Add(PageLabel);
            panel14.Controls.Add(label3);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(125, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(176, 50);
            panel14.TabIndex = 1;
            // 
            // PageLabel
            // 
            PageLabel.Dock = DockStyle.Fill;
            PageLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PageLabel.Location = new Point(56, 0);
            PageLabel.Name = "PageLabel";
            PageLabel.Padding = new Padding(0, 13, 0, 0);
            PageLabel.Size = new Size(120, 50);
            PageLabel.TabIndex = 1;
            PageLabel.Text = "1/50";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 13, 0, 0);
            label3.Size = new Size(56, 50);
            label3.TabIndex = 0;
            label3.Text = "Page:";
            // 
            // panel15
            // 
            panel15.Controls.Add(PreviousButton);
            panel15.Dock = DockStyle.Left;
            panel15.Location = new Point(0, 0);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(5);
            panel15.Size = new Size(125, 50);
            panel15.TabIndex = 0;
            // 
            // PreviousButton
            // 
            PreviousButton.Dock = DockStyle.Fill;
            PreviousButton.Location = new Point(5, 5);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(115, 40);
            PreviousButton.TabIndex = 0;
            PreviousButton.Text = "Previous";
            PreviousButton.UseVisualStyleBackColor = true;
            PreviousButton.Click += PreviousPageButton_Click;
            // 
            // panel16
            // 
            panel16.Controls.Add(NextButton);
            panel16.Dock = DockStyle.Left;
            panel16.Location = new Point(0, 0);
            panel16.Name = "panel16";
            panel16.Padding = new Padding(5);
            panel16.Size = new Size(120, 50);
            panel16.TabIndex = 0;
            // 
            // NextButton
            // 
            NextButton.Dock = DockStyle.Fill;
            NextButton.Location = new Point(5, 5);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(110, 40);
            NextButton.TabIndex = 0;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextPageButton_Click;
            // 
            // AuditLogDataGridView
            // 
            AuditLogDataGridView.AllowUserToAddRows = false;
            AuditLogDataGridView.AllowUserToDeleteRows = false;
            AuditLogDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AuditLogDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            AuditLogDataGridView.BorderStyle = BorderStyle.None;
            AuditLogDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AuditLogDataGridView.Dock = DockStyle.Fill;
            AuditLogDataGridView.Location = new Point(0, 0);
            AuditLogDataGridView.MultiSelect = false;
            AuditLogDataGridView.Name = "AuditLogDataGridView";
            AuditLogDataGridView.ReadOnly = true;
            AuditLogDataGridView.RowHeadersWidth = 51;
            AuditLogDataGridView.Size = new Size(965, 397);
            AuditLogDataGridView.TabIndex = 1;
            // 
            // BodyPanel_HeaderArea
            // 
            BodyPanel_HeaderArea.Controls.Add(panel2);
            BodyPanel_HeaderArea.Controls.Add(panel1);
            BodyPanel_HeaderArea.Dock = DockStyle.Top;
            BodyPanel_HeaderArea.Location = new Point(3, 3);
            BodyPanel_HeaderArea.Name = "BodyPanel_HeaderArea";
            BodyPanel_HeaderArea.Padding = new Padding(3);
            BodyPanel_HeaderArea.Size = new Size(965, 56);
            BodyPanel_HeaderArea.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(597, 50);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(AuditLogSearchTextBox);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(600, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(362, 50);
            panel1.TabIndex = 0;
            // 
            // AuditLogSearchTextBox
            // 
            AuditLogSearchTextBox.AnimateReadOnly = false;
            AuditLogSearchTextBox.BorderStyle = BorderStyle.None;
            AuditLogSearchTextBox.Depth = 0;
            AuditLogSearchTextBox.Dock = DockStyle.Fill;
            AuditLogSearchTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            AuditLogSearchTextBox.Hint = "Search logs";
            AuditLogSearchTextBox.LeadingIcon = null;
            AuditLogSearchTextBox.Location = new Point(0, 0);
            AuditLogSearchTextBox.MaxLength = 50;
            AuditLogSearchTextBox.MouseState = MaterialSkin.MouseState.OUT;
            AuditLogSearchTextBox.Multiline = false;
            AuditLogSearchTextBox.Name = "AuditLogSearchTextBox";
            AuditLogSearchTextBox.Size = new Size(362, 50);
            AuditLogSearchTextBox.TabIndex = 0;
            AuditLogSearchTextBox.Text = "";
            AuditLogSearchTextBox.TrailingIcon = (Image)resources.GetObject("AuditLogSearchTextBox.TrailingIcon");
            AuditLogSearchTextBox.UseAccent = false;
            AuditLogSearchTextBox.TextChanged += AuditLogSearchTextBox_TextChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(AuditLogDataGridView);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 59);
            panel3.Name = "panel3";
            panel3.Size = new Size(965, 397);
            panel3.TabIndex = 3;
            // 
            // ExportAuditLogModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 647);
            ControlBox = false;
            Controls.Add(BodyPanel);
            Controls.Add(FooterPanel);
            Controls.Add(HeaderPanel);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(1500, 665);
            MinimizeBox = false;
            MinimumSize = new Size(989, 665);
            Name = "ExportAuditLogModal";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += ExportAuditLogModal_Load;
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
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AuditLogDataGridView).EndInit();
            BodyPanel_HeaderArea.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
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
        private Panel BodyPanel_HeaderArea;
        private Panel HeaderPanel_TitleArea;
        private Label TitleLabel;
        private Label SectionRequiredLabel;
        private TextBox SettingValueTextBox;
        private Label SettingValueRequiredLabel;
        private Label label6;
        private TextBox SettingNameTextBox;
        private Label SettingNameRequiredLabel;
        private Label label4;
        private Panel panel9;
        private Panel panel11;
        private Panel panel10;
        private MaterialSkin.Controls.MaterialButton CancelButton;
        private MaterialSkin.Controls.MaterialButton ExportButton;
        private ComboBox SectionComboBox;
        private DataGridView AuditLogDataGridView;
        private SaveFileDialog ExportAuditLogs;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialTextBox AuditLogSearchTextBox;
        private Panel panel2;
        private Panel panel7;
        private Panel panel8;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Label PageLabel;
        private Label label3;
        private Panel panel15;
        private Button PreviousButton;
        private Panel panel16;
        private Button NextButton;
        private Panel panel3;
    }
}