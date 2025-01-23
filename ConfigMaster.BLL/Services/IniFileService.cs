using ConfigMaster.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public class IniFileService : IIniFileService
    {
        private readonly IIniFileRepository _iniFileRepository;
        public IniFileService(IIniFileRepository iniFileRepository)
        {
            _iniFileRepository = iniFileRepository;
        }

        public async Task<Dictionary<string, Dictionary<string, string>>> GetConfigurationData()
        {
            return await _iniFileRepository.GetConfigurationData();
        }

        public async Task<Dictionary<string, string>> GetKeyValuePairs(string section)
        {
            return await _iniFileRepository.GetKeyValues(section);
        }

        public async Task<IEnumerable<string>> GetSections()
        {
            return await _iniFileRepository.GetSections();
        }

        public async Task<bool> KeyExists(string section, string key)
        {
            return await _iniFileRepository.KeyExists(section, key);
        }

        public async Task LoadFile()
        {
            await _iniFileRepository.LoadFile();
        }

        public async Task<bool> SectionExists(string section)
        {
            return await _iniFileRepository.SectionExists(section);
        }

        public async Task<bool> UpdateKey(Dictionary<string, Dictionary<string, string>> configurationData, string section, string oldKey, string key, string value)
        {
            if (configurationData.TryGetValue(section, out var sectionData) && sectionData.ContainsKey(oldKey))
            {
                sectionData.Remove(oldKey);
                sectionData[key] = value;
                configurationData[section] = sectionData;
                return await _iniFileRepository.UpdateKey(configurationData);
            }
            return false;
        }

        public async Task WriteValue(string section, string key, string value)
        {
            await _iniFileRepository.WriteValue(section, key, value);
        }

        public async Task<bool> DeleteKey(string section, string key)
        {
            return await _iniFileRepository.DeleteKey(section, key);
        }

        public async Task<Dictionary<string, string>> CommentKey(Dictionary<string, Dictionary<string, string>> configurationData, string section, string key)
        {
            return await ToggleCommentKey(configurationData, section, key, comment: true);
        }

        public async Task<Dictionary<string, string>> UnCommentKey(Dictionary<string, Dictionary<string, string>> configurationData, string section, string key)
        {
            return await ToggleCommentKey(configurationData, section, key, comment: false);
        }

        private async Task<Dictionary<string, string>> ToggleCommentKey(Dictionary<string, Dictionary<string, string>> configurationData, string section, string key, bool comment)
        {
            var output = new Dictionary<string, string>();
            if (configurationData.TryGetValue(section, out var sectionData) && sectionData.ContainsKey(key))
            {
                string newKey = comment ? $";{key}" : key.TrimStart(';', '#');
                if (!comment && await KeyExists(section, newKey))
                {
                    throw new Exception($"Cannot uncomment setting because there is already an active setting enabled.");
                }

                string currentValue = sectionData[key];
                sectionData.Remove(key);
                sectionData[newKey] = currentValue;
                configurationData[section] = sectionData;
                await _iniFileRepository.UpdateKey(configurationData);
                output[newKey] = currentValue;
            }
            return output;
        }
    }
}
