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
            HeaderPanel_SearchBoxArea = new Panel();
            SearchTextBox = new MaterialSkin.Controls.MaterialTextBox();
            tabPage2 = new TabPage();
            FooterPanel = new Panel();
            label1 = new Label();
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
            FooterPanel.SuspendLayout();
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
            Menus.Size = new Size(1171, 661);
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
            tabPage1.Size = new Size(1163, 628);
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
            BodyPanel.Size = new Size(1157, 568);
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
            splitContainer1.Size = new Size(1157, 568);
            splitContainer1.SplitterDistance = 299;
            splitContainer1.TabIndex = 0;
            // 
            // SectionTreeView
            // 
            SectionTreeView.Dock = DockStyle.Fill;
            SectionTreeView.ImageIndex = 12;
            SectionTreeView.ImageList = imageList1;
            SectionTreeView.Location = new Point(0, 0);
            SectionTreeView.Name = "SectionTreeView";
            SectionTreeView.SelectedImageIndex = 13;
            SectionTreeView.Size = new Size(299, 568);
            SectionTreeView.TabIndex = 0;
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
            SettingsListView.Size = new Size(854, 568);
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
            addNewSettingToolStripMenuItem.Image = (Image)resources.GetObject("addNewSettingToolStripMenuItem.Image");
            addNewSettingToolStripMenuItem.Name = "addNewSettingToolStripMenuItem";
            addNewSettingToolStripMenuItem.Size = new Size(156, 44);
            addNewSettingToolStripMenuItem.Text = "Add New Setting";
            addNewSettingToolStripMenuItem.Click += AddNewSettingToolStripMenuItem_Click;
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
            tabPage2.ImageKey = "account.png";
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(1163, 628);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Account";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FooterPanel
            // 
            FooterPanel.Controls.Add(label1);
            FooterPanel.Dock = DockStyle.Bottom;
            FooterPanel.Location = new Point(3, 725);
            FooterPanel.Name = "FooterPanel";
            FooterPanel.Padding = new Padding(3, 3, 3, 6);
            FooterPanel.Size = new Size(1171, 22);
            FooterPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DodgerBlue;
            label1.Dock = DockStyle.Right;
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(1091, 3);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 1;
            label1.Text = "Build 1.0.1";
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
            DrawerTabControl = Menus;
            DrawerUseColors = true;
            MainMenuStrip = menuStripSetting;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Padding = new Padding(3, 64, 3, 4);
            RightToLeft = RightToLeft.No;
            Text = "Config Master";
            WindowState = FormWindowState.Maximized;
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
            FooterPanel.ResumeLayout(false);
            FooterPanel.PerformLayout();
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
        private Label label1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ContextMenuStrip contextMenuStripListView;
    }
}