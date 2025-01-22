using ConfigMaster.BLL.Services;
using ConfigMaster.ControlConfigurations;
using ConfigMaster.Modals;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConfigMaster
{
    public partial class MainForm : MaterialForm
    {
        private readonly IIniFileService _iniFileService;
        private readonly IPathManagerService _pathManagerService;
        private readonly IServiceProvider _serviceProvider;

        private ToolStripMenuItem _editOption = new ToolStripMenuItem("Edit");
        private ToolStripMenuItem _deleteOption = new ToolStripMenuItem("Delete");
        private ToolStripMenuItem _commentOption = new ToolStripMenuItem("Comment");
        private ToolStripMenuItem _uncommentOption = new ToolStripMenuItem("Uncomment");

        private string _selectedSection = string.Empty;
        private List<ListViewItem> _allItems = new();
        private ContextMenuStrip _menuStrip = new();

        public MainForm(IIniFileService iniFileService, IPathManagerService pathManagerService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitializeTreeView();
            InitializeContextMenu();
            MaterialSkinTheme materialSkin = new MaterialSkinTheme(this);
            materialSkin.SetTheme();

            _iniFileService = iniFileService;
            _pathManagerService = pathManagerService;
            _serviceProvider = serviceProvider;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateTreeview();
        }

        private void PopulateTreeview()
        {
            SectionTreeView.Nodes.Clear();
            LoadFileAsync().GetAwaiter().GetResult();
            var sections = _iniFileService.GetSections().GetAwaiter().GetResult();
            foreach (var section in sections)
            {
                var sectionNode = new TreeNode(section);
                sectionNode.Tag = section;
                sectionNode.NodeFont = new Font("Segoe UI", 10, FontStyle.Bold);
                SectionTreeView.Nodes.Add(sectionNode);
                sectionNode.Text = sectionNode.Text;
                SectionTreeView.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Ensure the TreeView control itself uses the same font
            }
        }

        private void InitializeTreeView()
        {
            // Set up the TreeView
            SectionTreeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            SectionTreeView.DrawNode += SectionTreeView_DrawNode;
            SectionTreeView.ShowLines = false;
            SectionTreeView.HotTracking = true;
            SectionTreeView.FullRowSelect = true;
        }

        private void SectionTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //// Draw the default node
            e.DrawDefault = true;

            // Custom drawing for selected nodes
            if (e.Node.IsSelected)
            {
                // Fill the background with white to remove the blue highlight
                Rectangle customBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, SectionTreeView.Width, e.Bounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 215)), customBounds);
                // Draw the focus rectangle
                ControlPaint.DrawFocusRectangle(e.Graphics, customBounds);
            }
        }

        private void SectionTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            bool isRightClick = e.Button == MouseButtons.Right;
            if (!isRightClick)
            {
                SectionTreeView.SelectedNode = e.Node;
                _selectedSection = e.Node.Tag?.ToString() ?? string.Empty;
                LoadItems();
            }
        }

        private void LoadItems()
        {
            if (string.IsNullOrEmpty(_selectedSection)) return;

            SettingsListView.Items.Clear();
            _allItems.Clear();
            var keyValues = _iniFileService.GetKeyValuePairs(_selectedSection).GetAwaiter().GetResult();

            foreach (var kvp in keyValues)
            {
                var item = new ListViewItem(kvp.Key);
                // Set font size and style to bold for the first column (setting name)
                item.UseItemStyleForSubItems = true;
                if (kvp.Key.StartsWith(';'))
                {
                    item.Font = new Font("Segoe UI", 10, FontStyle.Strikeout);
                    item.ForeColor = Color.Gray;
                }
                else
                {
                    item.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
                item.SubItems.Add(kvp.Value);
                item.ImageKey = "repair.png";
                SettingsListView.Items.Add(item);
                SettingsListView.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Ensure the ListView control itself uses the same font
                _allItems.Add((ListViewItem)item.Clone());
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            int searchLength = SearchTextBox.Text.Trim().Length;
            if (SettingsListView.Items.Count == 0 && searchLength > 0)
            {
                MessageBox.Show("No settings to search. Please select setting section", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SearchTextBox.Text = string.Empty;
                return;
            }
            else if (searchLength > 0)
            {
                FilterListView(SearchTextBox.Text.Trim());
            }
            else
            {
                LoadItems();
            }
        }

        private void FilterListView(string filterText)
        {
            string searchText = filterText.Trim().ToLower();
            SettingsListView.BeginUpdate();
            SettingsListView.Items.Clear();

            var filteredItems = _allItems.Where(item => item.Text.ToLower().Contains(searchText) || item.SubItems.Cast<ListViewItem.ListViewSubItem>().Any(sub => sub.Text.ToLower().Contains(searchText))).ToList();

            if (filteredItems.Count > 0)
            {
                SettingsListView.Items.AddRange(filteredItems.ToArray());
            }
            else
            {
                MessageBox.Show($"No results found for \"{filterText.Trim()}\"", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SettingsListView.Text = string.Empty;
                LoadItems();
            }

            SettingsListView.EndUpdate();
        }

        private void InitializeContextMenu()
        {
            _editOption = new ToolStripMenuItem("Edit");
            _editOption.Image = imageList1.Images["edit.png"];
            _editOption.Click += EditMenuItem_Click;
            _menuStrip.Items.Add(_editOption);
            _menuStrip.Items.Add(new ToolStripSeparator());

            _deleteOption = new ToolStripMenuItem("Delete");
            _deleteOption.Image = imageList1.Images["recycle-bin.png"];
            _menuStrip.Items.Add(_deleteOption);
            _menuStrip.Items.Add(new ToolStripSeparator());

            _commentOption = new ToolStripMenuItem("Comment");
            _commentOption.Image = imageList1.Images["eraser.png"];
            _menuStrip.Items.Add(_commentOption);
            _menuStrip.Items.Add(new ToolStripSeparator());

            _uncommentOption = new ToolStripMenuItem("Uncomment");
            _uncommentOption.Image = imageList1.Images["plus.png"];
            _menuStrip.Items.Add(_uncommentOption);

            SettingsListView.ContextMenuStrip = _menuStrip;
        }

        private void EditMenuItem_Click(object? sender, EventArgs e)
        {
            if (SettingsListView.SelectedItems.Count > 0 && SectionTreeView.SelectedNode != null)
            {
                string section = SectionTreeView.SelectedNode.Tag?.ToString() ?? string.Empty;
                ListViewItem selectedItem = SettingsListView.SelectedItems[0];
                string subItemText = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                var showModal = _serviceProvider.GetRequiredService<EditConfigurationModal>();
                showModal.Initialize(title: "Update Setting", isAdd: false, sections: null, section, selectedItem.Text, subItemText);
                showModal.ShowDialog();
            }
        }

        private async Task LoadFileAsync()
        {
            try
            {
                await _iniFileService.LoadFile();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iniBrowser.ShowDialog() == DialogResult.OK)
            {
                SettingsListView.Items.Clear();
                _pathManagerService.UpdatePath(iniBrowser.FileName).GetAwaiter().GetResult();
                PopulateTreeview();
            }
        }

        private void AddNewSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var showModal = _serviceProvider.GetRequiredService<EditConfigurationModal>();
            showModal.Initialize(title: "New Setting", isAdd: true, sections: _iniFileService.GetSections().GetAwaiter().GetResult());
            showModal.ShowDialog();
        }

        private void SettingsListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (SettingsListView.SelectedItems.Count > 0 && SectionTreeView.SelectedNode != null)
            {
                string section = SectionTreeView.SelectedNode.Tag?.ToString() ?? string.Empty;
                ListViewItem selectedItem = SettingsListView.SelectedItems[0];
                string subItemText = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                if (e.Button == MouseButtons.Right)
                {
                    if (selectedItem.Text.ToString().StartsWith(";") || selectedItem.Text.ToString().StartsWith("#"))
                    {
                        _commentOption.Enabled = false;
                        _uncommentOption.Enabled = true;
                        _editOption.Enabled = false;
                        _deleteOption.Enabled = false;
                    }
                    else
                    {
                        _commentOption.Enabled = true;
                        _uncommentOption.Enabled = false;
                        _editOption.Enabled = true;
                        _deleteOption.Enabled = true;
                    }

                    _menuStrip.Show(SettingsListView, e.Location);
                }
            }
        }
    }
}
