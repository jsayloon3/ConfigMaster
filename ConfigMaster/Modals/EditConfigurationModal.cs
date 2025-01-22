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
        private string _title;
        public EditConfigurationModal(string title)
        {
            InitializeComponent();
            _title = title;
        }

        private void EditConfigurationModal_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = _title;
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
