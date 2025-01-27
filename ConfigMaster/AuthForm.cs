using ConfigMaster.ControlConfigurations;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigMaster
{
    public partial class AuthForm : MaterialForm
    {
        public AuthForm()
        {
            InitializeComponent();
            MaterialSkinTheme materialSkin = new MaterialSkinTheme(this);
            materialSkin.SetTheme();

            // Enable double buffering for the form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Enable double buffering for all child controls
            EnableDoubleBuffering(this);
        }

        private void EnableDoubleBuffering(Control control)
        {
            foreach (Control c in control.Controls)
            {
                typeof(Control).InvokeMember("SetStyle",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                    null, c, new object[] { ControlStyles.OptimizedDoubleBuffer |
                                            ControlStyles.AllPaintingInWmPaint |
                                            ControlStyles.UserPaint, true });
                typeof(Control).InvokeMember("UpdateStyles",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                    null, c, null);
                if (c.HasChildren)
                {
                    EnableDoubleBuffering(c);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // WM_ERASEBKGND
            {
                return;
            }
            base.WndProc(ref m);
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }
    }
}
