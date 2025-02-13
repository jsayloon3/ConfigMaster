using ConfigMaster.BLL.Cache;
using ConfigMaster.BLL.Services;
using ConfigMaster.BLL.Session;
using ConfigMaster.Common.Enums;
using ConfigMaster.ControlConfigurations;
using ConfigMaster.Modals;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace ConfigMaster
{
    public partial class MainForm : MaterialForm
    {
        private readonly IIniFileService _iniFileService;
        private readonly IPathManagerService _pathManagerService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuditTrailManagerService _auditTrailManagerService;
        private readonly ILocalConfigurationPath _localConfigurationPath;

        private ToolStripMenuItem _editOption = new ToolStripMenuItem("Edit");
        private ToolStripMenuItem _deleteOption = new ToolStripMenuItem("Delete");
        private ToolStripMenuItem _commentOption = new ToolStripMenuItem("Comment");
        private ToolStripMenuItem _uncommentOption = new ToolStripMenuItem("Uncomment");

        private string _selectedSection = string.Empty;
        private List<ListViewItem> _allItems = new();

        private Dictionary<string, Dictionary<string, List<string>>> _readOnlySettings = new();

        public MainForm(IIniFileService iniFileService, IPathManagerService pathManagerService, IServiceProvider serviceProvider, IAuditTrailManagerService auditTrailManagerService, ILocalConfigurationPath localConfigurationPath)
        {
            InitializeComponent();
            InitializeMaterialSkin();
            EnableDoubleBuffering();
            InitializeContextMenu();

            _iniFileService = iniFileService;
            _pathManagerService = pathManagerService;
            _serviceProvider = serviceProvider;
            _auditTrailManagerService = auditTrailManagerService;
            _localConfigurationPath = localConfigurationPath;
        }

        private void InitializeMaterialSkin()
        {
            MaterialSkinTheme materialSkin = new MaterialSkinTheme(this);
            materialSkin.SetTheme();
        }

        private void EnableDoubleBuffering()
        {
            DoubleBuffering doubleBuffering = new DoubleBuffering(this);
            doubleBuffering.EnableDoubleBuffering(enableChildControlBuffering: false);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            EnsureOnlyReadOnlySettingsFileExists();
            LoadReadOnlySettings(Path.Combine(_localConfigurationPath.Path, "readonly_settings.json"));

            await PopulateSectionTreeviewAsync();
        }

        private async Task PopulateSectionTreeviewAsync()
        {
            // Display Filename on top
            FilenameLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FilenameLabel.Text = Path.GetFileName((await _pathManagerService.GetPath()).Path);

            // Todo: Implement control configuration
            var test = _localConfigurationPath.Path;


            SectionTreeView.Nodes.Clear();
            await LoadFileAsync();
            var sections = await _iniFileService.GetSections();
            foreach (var section in sections)
            {
                var sectionNode = new TreeNode(section)
                {
                    Tag = section,
                    NodeFont = new Font("Segoe UI", 10, FontStyle.Bold)
                };
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

            ApplyReadOnlySettings(iniFilename: FilenameLabel.Text);
        }

        private ListViewItem CreateListViewItem(string key, string value)
        {
            var item = new ListViewItem(key)
            {
                UseItemStyleForSubItems = false,
                Font = key.StartsWith(';') ? new Font("Segoe UI", 10, FontStyle.Strikeout) : new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = key.StartsWith(';') ? Color.Gray : Color.Black,
                ImageKey = "repair.png"
            };

            item.SubItems.Add(value);
            if (key.StartsWith(';') || key.StartsWith('#'))
            {
                item.SubItems[1].Font = new Font("Segoe UI", 10, FontStyle.Strikeout);
                item.SubItems[1].ForeColor = Color.Gray;
                item.SubItems.Add("Commented");
                item.SubItems[2].Font = new Font("Segoe UI", 10, FontStyle.Regular); // Set the font of the third subitem to normal
            }

            if (key.StartsWith('*'))
            {
                item.SubItems.Add("Read-Only");
                item.SubItems[2].Font = new Font("Segoe UI", 10, FontStyle.Regular); // Set the font of the third subitem to normal
            }

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
            contextMenuStripListView.Items.Add(_editOption);
            contextMenuStripListView.Items.Add(new ToolStripSeparator());

            _deleteOption = new ToolStripMenuItem("Delete");
            _deleteOption.Image = imageList1.Images["recycle-bin.png"];
            _deleteOption.Click += _deleteOption_Click;
            contextMenuStripListView.Items.Add(_deleteOption);
            contextMenuStripListView.Items.Add(new ToolStripSeparator());

            _commentOption = new ToolStripMenuItem("Comment");
            _commentOption.Image = imageList1.Images["eraser.png"];
            _commentOption.Click += _commentOption_Click;
            contextMenuStripListView.Items.Add(_commentOption);
            contextMenuStripListView.Items.Add(new ToolStripSeparator());

            _uncommentOption = new ToolStripMenuItem("Uncomment");
            _uncommentOption.Image = imageList1.Images["plus.png"];
            _uncommentOption.Click += _uncommentOption_Click;
            contextMenuStripListView.Items.Add(_uncommentOption);
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
                    if (selectedItem.Text.StartsWith(";") || selectedItem.Text.StartsWith("#"))
                    {
                        var configurationData = await _iniFileService.GetConfigurationData();
                        await _iniFileService.UnCommentKey(configurationData, section, selectedItem.Text);
                        selectedItem.Text = selectedItem.Text.Substring(1);
                    }

                    var isDeleted = await _iniFileService.DeleteKey(section, selectedItem.Text);
                    if (isDeleted)
                    {
                        SettingsListView.Items.RemoveAt(selectedItem.Index);
                        await _auditTrailManagerService.AddLog($"Deleted setting: [{section}] {selectedItem.Text}", AuditTrail.ActionType.Delete, "Success");
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
                selectedItem.Font = new Font("Segoe UI", 9f, FontStyle.Strikeout);
                selectedItem.ForeColor = Color.Gray;
                selectedItem.SubItems[1].Text = updatedKey.FirstOrDefault().Value;
                selectedItem.SubItems[1].Font = new Font("Segoe UI", 9f, FontStyle.Strikeout);
                selectedItem.SubItems[1].ForeColor = Color.Gray;
                selectedItem.SubItems.Add("Commented");
                SettingsListView.EndUpdate();

                await _auditTrailManagerService.AddLog($"Commented setting: [{section}] {updatedKey.FirstOrDefault().Key}={updatedKey.FirstOrDefault().Value}", AuditTrail.ActionType.Comment, "Success");
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
                selectedItem.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                selectedItem.ForeColor = Color.FromArgb(255, 0, 0, 0);
                selectedItem.SubItems[1].Text = updatedKey.FirstOrDefault().Value;
                selectedItem.SubItems[1].Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                selectedItem.SubItems[1].ForeColor = Color.FromArgb(255, 0, 0, 0);
                selectedItem.SubItems[2].Text = string.Empty;
                SettingsListView.EndUpdate();

                await _auditTrailManagerService.AddLog($"Uncomment setting: [{section}] {updatedKey.FirstOrDefault().Key}={updatedKey.FirstOrDefault().Value}", AuditTrail.ActionType.Uncomment, "Success");
            }
        }

        private async void EditMenuItem_Click(object? sender, EventArgs e)
        {
            if (SettingsListView.SelectedItems.Count > 0 && SectionTreeView.SelectedNode != null)
            {
                string section = SectionTreeView.SelectedNode.Tag?.ToString() ?? string.Empty;
                ListViewItem selectedItem = SettingsListView.SelectedItems[0];
                string subItemText = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : string.Empty;

                var edditSetting = _serviceProvider.GetRequiredService<EditConfigurationModal>();
                edditSetting.Initialize(title: "Update Setting", isAdd: false, isEdit: true, section, selectedItem.Text, subItemText);
                edditSetting.ShowDialog();


                if (edditSetting.IsUpdated)
                {
                    SettingsListView.BeginUpdate();
                    selectedItem.Text = edditSetting.GetResponseSettingName;
                    selectedItem.SubItems[1].Text = edditSetting.GetResponseSettingValue;
                    SettingsListView.EndUpdate();

                    await _auditTrailManagerService.AddLog($"Updated setting: [{edditSetting.GetResponseSectionName}] {edditSetting.GetResponseSettingName}={edditSetting.GetResponseSettingValue}", AuditTrail.ActionType.Update, "Success");
                }
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
                await _auditTrailManagerService.AddLog(message: "Loaded configuration", AuditTrail.ActionType.FileAccess, status: "Success");
                await PopulateSectionTreeviewAsync();
            }
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
                    _deleteOption.Enabled = true;

                    if (selectedItem.Tag != null && selectedItem.Tag.ToString() == "read-only")
                    {
                        contextMenuStripListView.Enabled = false;
                    }

                    contextMenuStripListView.Show(SettingsListView, e.Location);
                }
            }
        }

        private async void addNewSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addSetting = _serviceProvider.GetRequiredService<EditConfigurationModal>();
            addSetting.Initialize(title: "New Setting", isAdd: true, isEdit: false);
            addSetting.ShowDialog();


            if (addSetting.IsUpdated)
            {
                await _auditTrailManagerService.AddLog($"Added new setting: [{addSetting.GetResponseSectionName}] {addSetting.GetResponseSettingName}={addSetting.GetResponseSettingValue}", AuditTrail.ActionType.Create, "Success");

                if (!addSetting.IsSettingAddedOnExistingSection)
                {
                    var sectionNode = new TreeNode(addSetting.GetResponseSectionName)
                    {
                        Tag = addSetting.GetResponseSectionName,
                        NodeFont = new Font("Segoe UI", 10, FontStyle.Bold)
                    };

                    SectionTreeView.Nodes.Add(sectionNode);
                    sectionNode.Text = sectionNode.Text;
                    SectionTreeView.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Ensure the TreeView control itself uses the same font
                }

                if (SettingsListView.SelectedItems.Count > 0 || SectionTreeView.SelectedNode != null)
                {
                    SettingsListView.BeginUpdate();
                    var item = CreateListViewItem(addSetting.GetResponseSettingName, addSetting.GetResponseSettingValue);
                    SettingsListView.Items.Add(item);
                    SettingsListView.EndUpdate();
                }
            }
        }

        private async void LockButton_Click(object sender, EventArgs e)
        {
            await _auditTrailManagerService.AddLog($"Application locked", AuditTrail.ActionType.Lock, "Success");

            Hide();
            var launchAuthForm = _serviceProvider.GetRequiredService<AuthForm>();
            launchAuthForm.ShowDialog();
        }

        private void exportAuditLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportAuditLog = _serviceProvider.GetRequiredService<ExportAuditLogModal>();
            exportAuditLog.Initialize(title: "Export Audit Log");
            exportAuditLog.ShowDialog();
        }

        private void SettingsListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (SettingsListView.Items.Count == 0)
                {
                    // Disable the context menu if no items are loaded
                    contextMenuStripListView.Enabled = false;
                }
                else
                {
                    // Enable the context menu if items are loaded
                    contextMenuStripListView.Enabled = true;

                    // Check if the click is on an item
                    if (SettingsListView.HitTest(e.Location).Item == null)
                    {
                        // Disable the context menu if the click is not on an item
                        contextMenuStripListView.Enabled = false;
                    }
                }
            }
        }

        private void EnsureOnlyReadOnlySettingsFileExists()
        {
            string settingsDir = _localConfigurationPath.Path;

            if (Directory.Exists(settingsDir))
            {
                var jsonFiles = Directory.GetFiles(settingsDir, "*.json");

                foreach (var jsonFile in jsonFiles)
                {
                    string fileName = Path.GetFileName(jsonFile);
                    if (!fileName.Equals("readonly_settings.json", StringComparison.OrdinalIgnoreCase))
                    {
                        File.Delete(jsonFile); // Delete any unwanted JSON files
                        MessageBox.Show($"Unauthorized file '{fileName}' was removed.", "Security Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void LoadReadOnlySettings(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                _readOnlySettings = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(jsonContent) ?? new Dictionary<string, Dictionary<string, List<string>>>();
            }
            else
            {
                _readOnlySettings = new Dictionary<string, Dictionary<string, List<string>>>();
            }
        }

        private void ApplyReadOnlySettings(string iniFilename)
        {
            if (_readOnlySettings.ContainsKey(iniFilename))
            {
                var fileReadOnlySettings = _readOnlySettings[iniFilename];

                foreach (var section in fileReadOnlySettings)
                {
                    string sectionName = section.Key;
                    List<string> readOnlyKeys = section.Value;

                    foreach (ListViewItem item in SettingsListView.Items)
                    {
                        string itemSection = SectionTreeView.SelectedNode.Tag?.ToString() ?? string.Empty;
                        string itemKey = item.SubItems[0].Text;

                        if (itemSection == sectionName && readOnlyKeys.Contains(itemKey))
                        {
                            item.ForeColor = Color.Red;
                            item.SubItems[1].ForeColor = Color.Red;
                            item.Tag = "read-only";
                            item.SubItems.Add("Read-Only");
                        }
                    }
                }
            }
        }

        private async void importReadOnlySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "JSON Files (*json)|*.json",
                Title = "Import Read-Only Settings",
                FileName = "readonly_settings.json"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string importedFilePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(importedFilePath);
                string targetFilePath = Path.Combine(_localConfigurationPath.Path, "readonly_settings.json");

                // Block if the file is not named readonly_settings.json
                if (!fileName.Equals("readonly_settings.json", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Invalid file name! Please select 'readonly_settings.json' only", "Import Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Overwrite the existing file with the new one
                File.Copy(importedFilePath, targetFilePath, overwrite: true);

                LoadReadOnlySettings(targetFilePath);
                await LoadItemsAsync();
                await _auditTrailManagerService.AddLog($"Imported readonly_settings.json script", AuditTrail.ActionType.Import, "Success");

                MessageBox.Show("Read-only settings imported and saved successfully.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void expToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Export Read-Only Settings",
                FileName = "readonly_settings.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            { 
                string jsonContent = JsonSerializer.Serialize(_readOnlySettings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, jsonContent);
                await _auditTrailManagerService.AddLog($"Exported readonly_settings.json script", AuditTrail.ActionType.Export, "Success");
                MessageBox.Show("Read-only settings exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
