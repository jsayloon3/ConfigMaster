using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public interface IIniFileRepository
    {
        Task LoadFile();
        Task<Dictionary<string, Dictionary<string, string>>> GetConfigurationData();
        Task<IEnumerable<string>> GetSections();
        Task<Dictionary<string, string>> GetKeyValues(string section);
        Task WriteValue(string section, string key, string value);
        Task<bool> UpdateKey(Dictionary<string, Dictionary<string, string>> configurationData);
        Task<bool> DeleteKey(string section, string key);
        Task<bool> SectionExists(string section);
        Task<bool> KeyExists(string section, string key);
    }
}
