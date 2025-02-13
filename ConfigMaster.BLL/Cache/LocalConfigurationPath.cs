using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Cache
{
    public class LocalConfigurationPath : ILocalConfigurationPath
    {
        public string Path { get; private set; }
        public LocalConfigurationPath(string path)
        {
            Path = path;
        }
    }
}
