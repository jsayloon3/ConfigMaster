using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public interface IIniFileService
    {
        Task LoadFile();
        Task<IEnumerable<string>> GetSections();
        Task<Dictionary<string, string>> GetKeyValuePairs(string section);
    }
}
