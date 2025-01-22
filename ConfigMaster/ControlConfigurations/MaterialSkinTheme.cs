using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.ControlConfigurations
{
    public class MaterialSkinTheme
    {
        private MaterialForm _materialForm;
        public MaterialSkinTheme(MaterialForm materialForm)
        {
            _materialForm = materialForm;
        }

        public void SetTheme()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(_materialForm);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue100, Accent.Amber200, TextShade.WHITE);
        }
    }
}
