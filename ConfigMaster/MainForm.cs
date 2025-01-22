using ConfigMaster.ControlConfigurations;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigMaster
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MaterialSkinTheme materialSkin = new MaterialSkinTheme(this);
            materialSkin.SetTheme();
        }

        private void LoadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iniBrowser.ShowDialog() == DialogResult.OK)
            { 
                
            }
        }

        private void AddNewSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modals.EditConfigurationModal editConfigurationModal = new(title: "New Setting");
            editConfigurationModal.ShowDialog();
        }
    }
}
