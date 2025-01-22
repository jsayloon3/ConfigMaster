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
        public async Task<Dictionary<string, string>> GetKeyValuePairs(string section)
        {
            return await _iniFileRepository.GetKeyValues(section);
        }

        public async Task<IEnumerable<string>> GetSections()
        {
           return await _iniFileRepository.GetSections();
        }

        public async Task LoadFile()
        {
            await _iniFileRepository.LoadFile();
        }
    }
}
