using ConfigMaster.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigMaster.Modals
{
    public partial class EditConfigurationModal : Form
    {
        private string _title = string.Empty;
        private bool _isAdd = true;
        private bool _isEdit = false;
        private bool _isAddOnCurrentSection = false;
        private bool _isEditOnCurrentSection = false;
        private bool _isUpdated = false;
        private string _selectedSection = string.Empty;
        private string _selectedSettingName = string.Empty;
        private string _selectedSettingValue = string.Empty;

        private readonly IIniFileService _iniFileService;

        public EditConfigurationModal(IIniFileService iniFileService)
        {
            InitializeComponent();
            _iniFileService = iniFileService;
        }

        public void Initialize(string title, bool isAdd, bool isEdit, string selectedSection = "", string selectedSettingName = "", string selectedSettingValue = "")
        {
            _title = title;
            _isAdd = isAdd;
            _isEdit = isEdit;
            _selectedSection = selectedSection ?? string.Empty;
            _selectedSettingName = selectedSettingName ?? string.Empty;
            _selectedSettingValue = selectedSettingValue ?? string.Empty;
        }

        private void EditConfigurationModal_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = _title;
            if (_isAdd)
            {
                LoadSections();
            }
            else if (_isEdit)
            { 
                SectionComboBox.Text = _selectedSection;
                SectionComboBox.Enabled = false;
                SettingNameTextBox.Text = _selectedSettingName;
                SettingValueTextBox.Text = _selectedSettingValue;
            }
        }

        public bool IsUpdated => _isUpdated;
        public bool IsSettingAddedOnExistingSection => _isAddOnCurrentSection;
        public string GetResponseSectionName => _selectedSection;
        public string GetResponseSettingName => _selectedSettingName;
        public string GetResponseSettingValue => _selectedSettingValue;

        private void LoadSections()
        {
            SectionComboBox.Items.AddRange(_iniFileService.GetSections().Result.ToArray());
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldNotFilled())
            {
                ShowRequiredFieldLabel();
                SetFocusToFirstEmptyField();
            }
            else
            {
                // Extra validation
                string sectionName = SectionComboBox.Text.Trim();
                string settingName = SettingNameTextBox.Text.Trim();
                string settingValue = SettingValueTextBox.Text.Trim();
                bool isFirstCharIndicatingComment = settingName.StartsWith(";") || settingName.StartsWith("#");

                // No changes detected, auto close
                if (sectionName == _selectedSection && settingName == _selectedSettingName && settingValue == _selectedSettingValue) this.Close();

                // Check before updating configuration
                bool isSectionExists = await _iniFileService.SectionExists(sectionName);
                bool isKeyExists = await _iniFileService.KeyExists(sectionName, settingName);

                var configurationData = await _iniFileService.GetConfigurationData();
                configurationData.TryGetValue(sectionName, out var keyValuePairs);
                if (keyValuePairs != null && !isKeyExists)
                {
                    foreach (var keyValuePair in keyValuePairs)
                    {
                        if (keyValuePair.Key.StartsWith(";") || keyValuePair.Key.StartsWith("#"))
                        {
                            string currentSetting = keyValuePair.Key.Substring(1).Trim();
                            if (currentSetting.Equals(sectionName))
                            {
                                isKeyExists = true;
                                break;
                            }
                        }
                    }
                }

                if (isSectionExists || isKeyExists || isFirstCharIndicatingComment)
                {
                    if (isSectionExists && !_isAddOnCurrentSection && !_isEdit)
                    {
                        MessageBox.Show($"Section {sectionName} already exists.", "Section Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (isKeyExists && (_isAddOnCurrentSection || _isEditOnCurrentSection))
                    {
                        MessageBox.Show($"Setting {settingName} already exists.", "Setting Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (isFirstCharIndicatingComment)
                    {
                        MessageBox.Show($"Settings with a leading semicolon/hashtag are not valid. Please use the toolstrip menu to directly comment.", "Invalid Leading Semicolon/Hashtag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (_isAdd)
                {
                    await _iniFileService.WriteValue(sectionName, settingName, settingValue);
                    _isUpdated = true;
                    _selectedSection = sectionName;
                    _selectedSettingName = settingName;
                    _selectedSettingValue = settingValue;

                    MessageBox.Show($"Setting {settingName} has been added to {sectionName}.", "Setting Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else if (_isEdit)
                {
                    bool isUpdated = await _iniFileService.UpdateKey(configurationData, sectionName, _selectedSettingName, settingName, settingValue);
                    if (isUpdated)
                    {
                        _isUpdated = true;
                        _selectedSection = sectionName;
                        _selectedSettingName = settingName;
                        _selectedSettingValue = settingValue;

                        MessageBox.Show($"Setting {settingName} in {sectionName} has been updated.", "Setting Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool AreRequiredFieldNotFilled()
        {
            return string.IsNullOrWhiteSpace(SectionComboBox.Text) ||
                string.IsNullOrWhiteSpace(SettingNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(SettingValueTextBox.Text);
        }

        private void ShowRequiredFieldLabel()
        {
            SectionRequiredLabel.Visible = string.IsNullOrWhiteSpace(SectionComboBox.Text);
            SettingNameRequiredLabel.Visible = string.IsNullOrWhiteSpace(SettingNameTextBox.Text);
            SettingValueRequiredLabel.Visible = string.IsNullOrWhiteSpace(SettingValueTextBox.Text);
        }

        private void SetFocusToFirstEmptyField()
        {
            if (string.IsNullOrWhiteSpace(SectionComboBox.Text))
            {
                SectionComboBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(SettingNameTextBox.Text))
            {
                SettingNameTextBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(SettingValueTextBox.Text))
            {
                SettingValueTextBox.Focus();
            }
        }

        private void SectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SectionRequiredLabel.Visible = string.IsNullOrWhiteSpace(SectionComboBox.Text);
            _isAddOnCurrentSection = true;
            _selectedSection = SectionComboBox.Text.Trim();
        }

        private void SectionComboBox_TextChanged(object sender, EventArgs e)
        {
            SectionRequiredLabel.Visible = string.IsNullOrWhiteSpace(SectionComboBox.Text);
            if (_selectedSection != SectionComboBox.Text.Trim())
            {
                _isAddOnCurrentSection = false;
            }
        }

        private void SettingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingNameRequiredLabel.Visible = string.IsNullOrWhiteSpace(SettingNameTextBox.Text);
            if (_selectedSettingName != SettingNameTextBox.Text.Trim())
            {
                _isEditOnCurrentSection = true;
            }
            else if (_selectedSettingName == SettingNameTextBox.Text.Trim())
            {
                _isEditOnCurrentSection = false;
            }
        }

        private void SettingValueTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingValueRequiredLabel.Visible = string.IsNullOrWhiteSpace(SettingValueTextBox.Text);
        }
    }
}
