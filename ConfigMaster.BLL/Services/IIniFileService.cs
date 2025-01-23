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
        Task<Dictionary<string, Dictionary<string, string>>> GetConfigurationData();
        Task<IEnumerable<string>> GetSections();
        Task<Dictionary<string, string>> GetKeyValuePairs(string section);
        Task WriteValue(string section, string key, string value);
        Task<bool> UpdateKey(Dictionary<string, Dictionary<string, string>> configurationData, string section, string oldKey, string key, string value);
        Task<bool> DeleteKey(string section, string key);
        Task<bool> SectionExists(string section);
        Task<bool> KeyExists(string section, string key);
        Task<Dictionary<string, string>> CommentKey(Dictionary<string, Dictionary<string, string>> configurationData, string section, string key);
        Task<Dictionary<string, string>> UnCommentKey(Dictionary<string, Dictionary<string, string>> configurationData, string section, string key);
    }
}
