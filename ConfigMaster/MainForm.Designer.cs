using ConfigMaster.ControlConfigurations;

namespace ConfigMaster
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            imageList1 = new ImageList(components);
            Menus = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            BodyPanel = new Panel();
            splitContainer1 = new SplitContainer();
            SectionTreeView = new TreeView();
            SettingsListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            contextMenuStripListView = new ContextMenuStrip(components);
            HeaderPanel = new Panel();
            HeaderPanel_ContextMenuArea = new Panel();
            menuStripSetting = new MenuStrip();
            loadConfigurationToolStripMenuItem = new ToolStripMenuItem();
            addNewSettingToolStripMenuItem = new ToolStripMenuItem();
            addNewSettingToolStripMenuItem1 = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            readOnlySettingsToolStripMenuItem = new ToolStripMenuItem();
            exportAuditLogsToolStripMenuItem = new ToolStripMenuItem();
            HeaderPanel_SearchBoxArea = new Panel();
            SearchTextBox = new MaterialSkin.Controls.MaterialTextBox();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            panel5 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            LogoutButton = new MaterialSkin.Controls.MaterialButton();
            AccountHeaderPanel = new FlowLayoutPanel();
            AccountGreetingLabel = new MaterialSkin.Controls.MaterialLabel();
            AccountLeftPanel = new FlowLayoutPanel();
            AccountRightPanel = new FlowLayoutPanel();
            FooterPanel = new Panel();
            panel8 = new Panel();
            LockButton = new MaterialSkin.Controls.MaterialButton();
            iniBrowser = new OpenFileDialog();
            Menus.SuspendLayout();
            tabPage1.SuspendLayout();
            BodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            HeaderPanel.SuspendLayout();
            HeaderPanel_ContextMenuArea.SuspendLayout();
            menuStripSetting.SuspendLayout();
            HeaderPanel_SearchBoxArea.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            AccountHeaderPanel.SuspendLayout();
            FooterPanel.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "account.png");
            imageList1.Images.SetKeyName(1, "add_setting.png");
            imageList1.Images.SetKeyName(2, "document.png");
            imageList1.Images.SetKeyName(3, "edit.png");
            imageList1.Images.SetKeyName(4, "eraser.png");
            imageList1.Images.SetKeyName(5, "folder.png");
            imageList1.Images.SetKeyName(6, "home.png");
            imageList1.Images.SetKeyName(7, "load_configuration.png");
            imageList1.Images.SetKeyName(8, "plus.png");
            imageList1.Images.SetKeyName(9, "recycle-bin.png");
            imageList1.Images.SetKeyName(10, "repair.png");
            imageList1.Images.SetKeyName(11, "search.png");
            imageList1.Images.SetKeyName(12, "section.png");
            imageList1.Images.SetKeyName(13, "section_active.png");
            // 
            // Menus
            // 
            Menus.Controls.Add(tabPage1);
            Menus.Controls.Add(tabPage2);
            Menus.Depth = 0;
            Menus.Dock = DockStyle.Fill;
            Menus.ImageList = imageList1;
            Menus.Location = new Point(3, 64);
            Menus.Margin = new Padding(0);
            Menus.MouseState = MaterialSkin.MouseState.HOVER;
            Menus.Multiline = true;
            Menus.Name = "Menus";
            Menus.SelectedIndex = 0;
            Menus.Size = new Size(1171, 648);
            Menus.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BodyPanel);
            tabPage1.Controls.Add(HeaderPanel);
            tabPage1.ImageKey = "home.png";
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1163, 615);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BodyPanel
            // 
            BodyPanel.Controls.Add(splitContainer1);
            BodyPanel.Dock = DockStyle.Fill;
            BodyPanel.Location = new Point(3, 56);
            BodyPanel.Name = "BodyPanel";
            BodyPanel.Size = new Size(1157, 555);
            BodyPanel.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(SectionTreeView);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(SettingsListView);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(1157, 555);
            splitContainer1.SplitterDistance = 248;
            splitContainer1.TabIndex = 0;
            // 
            // SectionTreeView
            // 
            SectionTreeView.Dock = DockStyle.Fill;
            SectionTreeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            SectionTreeView.FullRowSelect = true;
            SectionTreeView.HideSelection = false;
            SectionTreeView.HotTracking = true;
            SectionTreeView.ImageIndex = 12;
            SectionTreeView.ImageList = imageList1;
            SectionTreeView.Location = new Point(0, 0);
            SectionTreeView.Name = "SectionTreeView";
            SectionTreeView.SelectedImageIndex = 13;
            SectionTreeView.ShowLines = false;
            SectionTreeView.Size = new Size(248, 555);
            SectionTreeView.TabIndex = 0;
            SectionTreeView.DrawNode += SectionTreeView_DrawNode;
            SectionTreeView.NodeMouseClick += SectionTreeView_NodeMouseClick;
            // 
            // SettingsListView
            // 
            SettingsListView.Activation = ItemActivation.OneClick;
            SettingsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            SettingsListView.ContextMenuStrip = contextMenuStripListView;
            SettingsListView.Dock = DockStyle.Fill;
            SettingsListView.FullRowSelect = true;
            SettingsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            SettingsListView.HotTracking = true;
            SettingsListView.HoverSelection = true;
            SettingsListView.Location = new Point(0, 0);
            SettingsListView.MultiSelect = false;
            SettingsListView.Name = "SettingsListView";
            SettingsListView.ShowItemToolTips = true;
            SettingsListView.Size = new Size(905, 555);
            SettingsListView.SmallImageList = imageList1;
            SettingsListView.TabIndex = 0;
            SettingsListView.UseCompatibleStateImageBehavior = false;
            SettingsListView.View = View.Details;
            SettingsListView.MouseClick += SettingsListView_MouseClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Settings Name";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Settings Value";
            columnHeader2.Width = 600;
            // 
            // contextMenuStripListView
            // 
            contextMenuStripListView.ImageScalingSize = new Size(20, 20);
            contextMenuStripListView.Name = "contextMenuStripListView";
            contextMenuStripListView.Size = new Size(61, 4);
            // 
            // HeaderPanel
            // 
            HeaderPanel.BorderStyle = BorderStyle.FixedSingle;
            HeaderPanel.Controls.Add(HeaderPanel_ContextMenuArea);
            HeaderPanel.Controls.Add(HeaderPanel_SearchBoxArea);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(3, 4);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1157, 52);
            HeaderPanel.TabIndex = 0;
            // 
            // HeaderPanel_ContextMenuArea
            // 
            HeaderPanel_ContextMenuArea.Controls.Add(menuStripSetting);
            HeaderPanel_ContextMenuArea.Dock = DockStyle.Left;
            HeaderPanel_ContextMenuArea.Location = new Point(0, 0);
            HeaderPanel_ContextMenuArea.Margin = new Padding(3, 4, 3, 4);
            HeaderPanel_ContextMenuArea.Name = "HeaderPanel_ContextMenuArea";
            HeaderPanel_ContextMenuArea.Size = new Size(640, 50);
            HeaderPanel_ContextMenuArea.TabIndex = 1;
            // 
            // menuStripSetting
            // 
            menuStripSetting.Dock = DockStyle.Fill;
            menuStripSetting.ImageScalingSize = new Size(20, 20);
            menuStripSetting.Items.AddRange(new ToolStripItem[] { loadConfigurationToolStripMenuItem, addNewSettingToolStripMenuItem });
            menuStripSetting.Location = new Point(0, 0);
            menuStripSetting.Name = "menuStripSetting";
            menuStripSetting.Padding = new Padding(3);
            menuStripSetting.Size = new Size(640, 50);
            menuStripSetting.TabIndex = 0;
            menuStripSetting.Text = "menuStrip1";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            loadConfigurationToolStripMenuItem.Image = (Image)resources.GetObject("loadConfigurationToolStripMenuItem.Image");
            loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            loadConfigurationToolStripMenuItem.Size = new Size(171, 44);
            loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            loadConfigurationToolStripMenuItem.Click += LoadConfigurationToolStripMenuItem_Click;
            // 
            // addNewSettingToolStripMenuItem
            // 
            addNewSettingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addNewSettingToolStripMenuItem1, importToolStripMenuItem, exportAuditLogsToolStripMenuItem });
            addNewSettingToolStripMenuItem.Image = (Image)resources.GetObject("addNewSettingToolStripMenuItem.Image");
            addNewSettingToolStripMenuItem.Name = "addNewSettingToolStripMenuItem";
            addNewSettingToolStripMenuItem.Size = new Size(66, 44);
            addNewSettingToolStripMenuItem.Text = "File";
            addNewSettingToolStripMenuItem.Click += AddNewSettingToolStripMenuItem_Click;
            // 
            // addNewSettingToolStripMenuItem1
            // 
            addNewSettingToolStripMenuItem1.Image = (Image)resources.GetObject("addNewSettingToolStripMenuItem1.Image");
            addNewSettingToolStripMenuItem1.Name = "addNewSettingToolStripMenuItem1";
            addNewSettingToolStripMenuItem1.Size = new Size(224, 26);
            addNewSettingToolStripMenuItem1.Text = "Add New Setting";
            addNewSettingToolStripMenuItem1.Click += addNewSettingToolStripMenuItem1_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { readOnlySettingsToolStripMenuItem });
            importToolStripMenuItem.Image = (Image)resources.GetObject("importToolStripMenuItem.Image");
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(224, 26);
            importToolStripMenuItem.Text = "Import Scripts";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // readOnlySettingsToolStripMenuItem
            // 
            readOnlySettingsToolStripMenuItem.Image = (Image)resources.GetObject("readOnlySettingsToolStripMenuItem.Image");
            readOnlySettingsToolStripMenuItem.Name = "readOnlySettingsToolStripMenuItem";
            readOnlySettingsToolStripMenuItem.Size = new Size(288, 26);
            readOnlySettingsToolStripMenuItem.Text = "Configure Read-Only Settings";
            // 
            // exportAuditLogsToolStripMenuItem
            // 
            exportAuditLogsToolStripMenuItem.Image = (Image)resources.GetObject("exportAuditLogsToolStripMenuItem.Image");
            exportAuditLogsToolStripMenuItem.Name = "exportAuditLogsToolStripMenuItem";
            exportAuditLogsToolStripMenuItem.Size = new Size(224, 26);
            exportAuditLogsToolStripMenuItem.Text = "Export Audit Logs";
            // 
            // HeaderPanel_SearchBoxArea
            // 
            HeaderPanel_SearchBoxArea.Controls.Add(SearchTextBox);
            HeaderPanel_SearchBoxArea.Dock = DockStyle.Right;
            HeaderPanel_SearchBoxArea.Location = new Point(641, 0);
            HeaderPanel_SearchBoxArea.Margin = new Padding(0);
            HeaderPanel_SearchBoxArea.Name = "HeaderPanel_SearchBoxArea";
            HeaderPanel_SearchBoxArea.Size = new Size(514, 50);
            HeaderPanel_SearchBoxArea.TabIndex = 0;
            // 
            // SearchTextBox
            // 
            SearchTextBox.AnimateReadOnly = false;
            SearchTextBox.BorderStyle = BorderStyle.None;
            SearchTextBox.Depth = 0;
            SearchTextBox.Dock = DockStyle.Fill;
            SearchTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            SearchTextBox.Hint = "Search settings";
            SearchTextBox.LeadingIcon = null;
            SearchTextBox.Location = new Point(0, 0);
            SearchTextBox.Margin = new Padding(3, 4, 3, 4);
            SearchTextBox.MaxLength = 1000;
            SearchTextBox.MouseState = MaterialSkin.MouseState.OUT;
            SearchTextBox.Multiline = false;
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(514, 50);
            SearchTextBox.TabIndex = 0;
            SearchTextBox.Text = "";
            SearchTextBox.TrailingIcon = (Image)resources.GetObject("SearchTextBox.TrailingIcon");
            SearchTextBox.UseAccent = false;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(AccountHeaderPanel);
            tabPage2.Controls.Add(AccountLeftPanel);
            tabPage2.Controls.Add(AccountRightPanel);
            tabPage2.ImageKey = "account.png";
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 50, 3, 3);
            tabPage2.Size = new Size(1163, 615);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Account";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(283, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 526);
            panel1.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(192, 0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(0, 20, 0, 20);
            panel6.Size = new Size(211, 475);
            panel6.TabIndex = 3;
            // 
            // panel7
            // 
            panel7.Controls.Add(materialButton1);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 20);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(15, 5, 15, 5);
            panel7.Size = new Size(211, 44);
            panel7.TabIndex = 0;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.Dock = DockStyle.Fill;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(15, 5);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(181, 34);
            materialButton1.TabIndex = 0;
            materialButton1.Text = "View Logs";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(403, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(192, 475);
            panel5.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(192, 475);
            panel4.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 475);
            panel2.Name = "panel2";
            panel2.Size = new Size(595, 49);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(LogoutButton);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(444, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(151, 49);
            panel3.TabIndex = 0;
            // 
            // LogoutButton
            // 
            LogoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LogoutButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            LogoutButton.Depth = 0;
            LogoutButton.Dock = DockStyle.Fill;
            LogoutButton.HighEmphasis = true;
            LogoutButton.Icon = null;
            LogoutButton.Location = new Point(5, 5);
            LogoutButton.Margin = new Padding(4, 6, 4, 6);
            LogoutButton.MouseState = MaterialSkin.MouseState.HOVER;
            LogoutButton.Name = "LogoutButton";
            LogoutButton.NoAccentTextColor = Color.Empty;
            LogoutButton.Size = new Size(141, 39);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Logout";
            LogoutButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            LogoutButton.UseAccentColor = false;
            LogoutButton.UseVisualStyleBackColor = true;
            // 
            // AccountHeaderPanel
            // 
            AccountHeaderPanel.Controls.Add(AccountGreetingLabel);
            AccountHeaderPanel.Dock = DockStyle.Top;
            AccountHeaderPanel.Location = new Point(283, 50);
            AccountHeaderPanel.Name = "AccountHeaderPanel";
            AccountHeaderPanel.Size = new Size(597, 36);
            AccountHeaderPanel.TabIndex = 2;
            // 
            // AccountGreetingLabel
            // 
            AccountGreetingLabel.AutoSize = true;
            AccountGreetingLabel.Depth = 0;
            AccountGreetingLabel.Dock = DockStyle.Fill;
            AccountGreetingLabel.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            AccountGreetingLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            AccountGreetingLabel.Location = new Point(3, 0);
            AccountGreetingLabel.MouseState = MaterialSkin.MouseState.HOVER;
            AccountGreetingLabel.Name = "AccountGreetingLabel";
            AccountGreetingLabel.Size = new Size(178, 29);
            AccountGreetingLabel.TabIndex = 0;
            AccountGreetingLabel.Text = "Good Afternoon!";
            // 
            // AccountLeftPanel
            // 
            AccountLeftPanel.Dock = DockStyle.Left;
            AccountLeftPanel.Location = new Point(3, 50);
            AccountLeftPanel.Name = "AccountLeftPanel";
            AccountLeftPanel.Size = new Size(280, 562);
            AccountLeftPanel.TabIndex = 1;
            // 
            // AccountRightPanel
            // 
            AccountRightPanel.Dock = DockStyle.Right;
            AccountRightPanel.Location = new Point(880, 50);
            AccountRightPanel.Name = "AccountRightPanel";
            AccountRightPanel.Size = new Size(280, 562);
            AccountRightPanel.TabIndex = 0;
            // 
            // FooterPanel
            // 
            FooterPanel.Controls.Add(panel8);
            FooterPanel.Dock = DockStyle.Bottom;
            FooterPanel.Location = new Point(3, 712);
            FooterPanel.Name = "FooterPanel";
            FooterPanel.Padding = new Padding(3, 3, 3, 6);
            FooterPanel.Size = new Size(1171, 35);
            FooterPanel.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(LockButton);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(1064, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(104, 26);
            panel8.TabIndex = 0;
            // 
            // LockButton
            // 
            LockButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LockButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            LockButton.Depth = 0;
            LockButton.Dock = DockStyle.Fill;
            LockButton.HighEmphasis = true;
            LockButton.Icon = (Image)resources.GetObject("LockButton.Icon");
            LockButton.Location = new Point(0, 0);
            LockButton.Margin = new Padding(4, 6, 4, 6);
            LockButton.MouseState = MaterialSkin.MouseState.HOVER;
            LockButton.Name = "LockButton";
            LockButton.NoAccentTextColor = Color.Empty;
            LockButton.Size = new Size(104, 26);
            LockButton.TabIndex = 0;
            LockButton.Text = "Lock";
            LockButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            LockButton.UseAccentColor = false;
            LockButton.UseVisualStyleBackColor = true;
            // 
            // iniBrowser
            // 
            iniBrowser.Filter = "Ini files (*.ini)|*.ini";
            iniBrowser.Title = "Select Configuration";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 751);
            Controls.Add(Menus);
            Controls.Add(FooterPanel);
            DrawerIndicatorWidth = 5;
            DrawerUseColors = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStripSetting;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1177, 751);
            Name = "MainForm";
            Padding = new Padding(3, 64, 3, 4);
            RightToLeft = RightToLeft.No;
            Text = "Config Master";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Menus.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            BodyPanel.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            HeaderPanel.ResumeLayout(false);
            HeaderPanel_ContextMenuArea.ResumeLayout(false);
            HeaderPanel_ContextMenuArea.PerformLayout();
            menuStripSetting.ResumeLayout(false);
            menuStripSetting.PerformLayout();
            HeaderPanel_SearchBoxArea.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            AccountHeaderPanel.ResumeLayout(false);
            AccountHeaderPanel.PerformLayout();
            FooterPanel.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl Menus;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel HeaderPanel;
        private Panel HeaderPanel_ContextMenuArea;
        private Panel HeaderPanel_SearchBoxArea;
        private MaterialSkin.Controls.MaterialTextBox SearchTextBox;
        private MenuStrip menuStripSetting;
        private ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private ToolStripMenuItem addNewSettingToolStripMenuItem;
        private Panel BodyPanel;
        private Panel FooterPanel;
        private SplitContainer splitContainer1;
        private TreeView SectionTreeView;
        private ListView SettingsListView;
        private OpenFileDialog iniBrowser;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ContextMenuStrip contextMenuStripListView;
        private FlowLayoutPanel AccountRightPanel;
        private FlowLayoutPanel AccountLeftPanel;
        private FlowLayoutPanel AccountHeaderPanel;
        private MaterialSkin.Controls.MaterialLabel AccountGreetingLabel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private MaterialSkin.Controls.MaterialButton LogoutButton;
        private Panel panel6;
        private Panel panel7;
        private Panel panel5;
        private Panel panel4;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private Panel panel8;
        private MaterialSkin.Controls.MaterialButton LockButton;
        private ToolStripMenuItem addNewSettingToolStripMenuItem1;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportAuditLogsToolStripMenuItem;
        private ToolStripMenuItem readOnlySettingsToolStripMenuItem;
    }
}