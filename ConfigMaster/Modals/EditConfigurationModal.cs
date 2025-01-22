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
        private string _selectedSection = string.Empty;
        private string _selectedSettingName = string.Empty;
        private string _selectedSettingValue = string.Empty;

        private IEnumerable<string> _sections = new List<string>();

        public EditConfigurationModal()
        {
            InitializeComponent();
        }

        public void Initialize(string title, bool isAdd, IEnumerable<string>? sections, string selectedSection = "", string selectedSettingName = "", string selectedSettingValue = "")
        {
            _title = title;
            _isAdd = isAdd;
            _selectedSection = selectedSection ?? string.Empty;
            _selectedSettingName = selectedSettingName ?? string.Empty;
            _selectedSettingValue = selectedSettingValue ?? string.Empty;
            _sections = sections ?? new List<string>();
        }

        private void EditConfigurationModal_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = _title;
            if (_isAdd)
            {
                LoadSections();
            }
            else
            { 
                SectionComboBox.Text = _selectedSection;
                SectionComboBox.Enabled = false;
                SettingNameTextBox.Text = _selectedSettingName;
                SettingValueTextBox.Text = _selectedSettingValue;
            }
        }

        private void LoadSections()
        {
            SectionComboBox.Items.AddRange(_sections.ToArray());
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldNotFilled())
            {
                ShowRequiredFieldLabel();
                SetFocusToFirstEmptyField();
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
        }

        private void SectionComboBox_TextChanged(object sender, EventArgs e)
        {
            SectionRequiredLabel.Visible = string.IsNullOrWhiteSpace(SectionComboBox.Text);
        }

        private void SettingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingNameRequiredLabel.Visible = string.IsNullOrWhiteSpace(SettingNameTextBox.Text);
        }

        private void SettingValueTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingValueRequiredLabel.Visible = string.IsNullOrWhiteSpace(SettingValueTextBox.Text);
        }
    }
}
