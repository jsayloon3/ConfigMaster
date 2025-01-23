using ConfigMaster.BLL.Services;
using ConfigMaster.ControlConfigurations;
using ConfigMaster.Modals;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
            InitializeContextMenu();
            MaterialSkinTheme materialSkin = new MaterialSkinTheme(this);
            materialSkin.SetTheme();

            _iniFileService = iniFileService;
            _pathManagerService = pathManagerService;
            _serviceProvider = serviceProvider;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await PopulateSectionTreeviewAsync();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async Task PopulateSectionTreeviewAsync()
        {
            SectionTreeView.Nodes.Clear();
            await LoadFileAsync();
            var sections = await _iniFileService.GetSections();
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

        private void SectionTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Draw the default node
            e.DrawDefault = true;

            // Custom drawing for selected nodes
            if (e.Node.IsSelected)
            {
                Rectangle customBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, SectionTreeView.Width, e.Bounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 215)), customBounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, customBounds);
            }
        }

        private void SectionTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                SectionTreeView.SelectedNode = e.Node;
                _selectedSection = e.Node.Tag?.ToString() ?? string.Empty;
                LoadItemsAsync().ConfigureAwait(false);
            }
        }

        private async Task LoadItemsAsync()
        {
            if (string.IsNullOrEmpty(_selectedSection)) return;

            SettingsListView.Items.Clear();
            _allItems.Clear();
            var keyValues = await _iniFileService.GetKeyValuePairs(_selectedSection);

            foreach (var kvp in keyValues)
            {
                var item = CreateListViewItem(kvp.Key, kvp.Value);
                SettingsListView.Items.Add(item);
                _allItems.Add((ListViewItem)item.Clone());
            }
            SettingsListView.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Ensure the ListView control itself uses the same font
        }

        private ListViewItem CreateListViewItem(string key, string value)
        {
            var item = new ListViewItem(key)
            {
                UseItemStyleForSubItems = true,
                Font = key.StartsWith(';') ? new Font("Segoe UI", 10, FontStyle.Strikeout) : new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = key.StartsWith(';') ? Color.Gray : Color.Black,
                ImageKey = "repair.png"
            };
            item.SubItems.Add(value);
            return item;
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
                LoadItemsAsync().ConfigureAwait(false);
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
                LoadItemsAsync().ConfigureAwait(false);
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
            _deleteOption.Click += _deleteOption_Click;
            _menuStrip.Items.Add(_deleteOption);
            _menuStrip.Items.Add(new ToolStripSeparator());

            _commentOption = new ToolStripMenuItem("Comment");
            _commentOption.Image = imageList1.Images["eraser.png"];
            _commentOption.Click += _commentOption_Click;
            _menuStrip.Items.Add(_commentOption);
            _menuStrip.Items.Add(new ToolStripSeparator());

            _uncommentOption = new ToolStripMenuItem("Uncomment");
            _uncommentOption.Image = imageList1.Images["plus.png"];
            _uncommentOption.Click += _uncommentOption_Click;
            _menuStrip.Items.Add(_uncommentOption);

            SettingsListView.ContextMenuStrip = _menuStrip;
        }

        private async void _deleteOption_Click(object? sender, EventArgs e)
        {
            if (SettingsListView.SelectedItems.Count > 0 && SectionTreeView.SelectedNode != null)
            {
                string section = SectionTreeView.SelectedNode.Tag?.ToString() ?? string.Empty;
                ListViewItem selectedItem = SettingsListView.SelectedItems[0];
                string subItemText = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                if (MessageBox.Show(
                        $"Do you want to remove this {selectedItem.Text}={subItemText} setting?",
                        "Remove Setting",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                { 
                    var isDeleted = await _iniFileService.DeleteKey(section, selectedItem.Text);
                    if (isDeleted)
                    {
                        SettingsListView.Items.RemoveAt(selectedItem.Index);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void _commentOption_Click(object? sender, EventArgs e)
        {
            if (SettingsListView.SelectedItems.Count > 0 && SectionTreeView.SelectedNode != null)
            {
                string section = SectionTreeView.SelectedNode.Tag?.ToString() ?? string.Empty;
                ListViewItem selectedItem = SettingsListView.SelectedItems[0];
                string subItemText = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                var configurationData = await _iniFileService.GetConfigurationData();
                var updatedKey = await _iniFileService.CommentKey(configurationData, section, selectedItem.Text);
                SettingsListView.BeginUpdate();
                selectedItem.Text = updatedKey.FirstOrDefault().Key;
                selectedItem.SubItems[1].Text = updatedKey.FirstOrDefault().Value;
                selectedItem.Font = new Font("Segoe UI", 9f, FontStyle.Strikeout);
                selectedItem.ForeColor = Color.Gray;
                SettingsListView.EndUpdate();
            }
        }

        private async void _uncommentOption_Click(object? sender, EventArgs e)
        {
            if (SettingsListView.SelectedItems.Count > 0 && SectionTreeView.SelectedNode != null)
            {
                string section = SectionTreeView.SelectedNode.Tag?.ToString() ?? string.Empty;
                ListViewItem selectedItem = SettingsListView.SelectedItems[0];
                string subItemText = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                var configurationData = await _iniFileService.GetConfigurationData();
                var updatedKey = await _iniFileService.UnCommentKey(configurationData, section, selectedItem.Text);
                SettingsListView.BeginUpdate();
                selectedItem.Text = updatedKey.FirstOrDefault().Key;
                selectedItem.SubItems[1].Text = updatedKey.FirstOrDefault().Value;
                selectedItem.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                selectedItem.ForeColor = Color.FromArgb(255, 0, 0, 0);
                SettingsListView.EndUpdate();
            }
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

        private async void LoadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iniBrowser.ShowDialog() == DialogResult.OK)
            {
                SettingsListView.Items.Clear();
                await _pathManagerService.UpdatePath(iniBrowser.FileName);
                await PopulateSectionTreeviewAsync();
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
                ListViewItem selectedItem = SettingsListView.SelectedItems[0];

                if (e.Button == MouseButtons.Right)
                {
                    bool isCommented = selectedItem.Text.ToString().StartsWith(";") || selectedItem.Text.ToString().StartsWith("#");

                    _commentOption.Enabled = !isCommented;
                    _uncommentOption.Enabled = isCommented;
                    _editOption.Enabled = !isCommented;
                    _deleteOption.Enabled = !isCommented;

                    _menuStrip.Show(SettingsListView, e.Location);
                }
            }
        }
    }
}
