using MaterialSkin.Controls;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ConfigMaster.ControlConfigurations
{
    public class DoubleBuffering : MaterialForm
    {
        private readonly MaterialForm _materialForm;

        public DoubleBuffering(MaterialForm materialForm)
        {
            _materialForm = materialForm ?? throw new ArgumentNullException(nameof(materialForm));
        }

        public void EnableDoubleBuffering(bool enableChildControlBuffering = true)
        {
            // Enable double buffering for the form
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            UpdateStyles();

            // Enable double buffering for all child controls
            if(enableChildControlBuffering) ChildControlBuffering(_materialForm);
        }

        private void ChildControlBuffering(Control control)
        {
            foreach (Control c in control.Controls)
            {
                try
                {
                    typeof(Control).InvokeMember("SetStyle",
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                        null, c, new object[] { ControlStyles.OptimizedDoubleBuffer |
                                                ControlStyles.AllPaintingInWmPaint |
                                                ControlStyles.UserPaint, true });
                    typeof(Control).InvokeMember("UpdateStyles",
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                        null, c, null);

                    // Recursively apply double buffering to child controls
                    if (c.HasChildren)
                    {
                        ChildControlBuffering(c);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"Error enabling double buffering for control {c.Name}: {ex.Message}");
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
    }
}
