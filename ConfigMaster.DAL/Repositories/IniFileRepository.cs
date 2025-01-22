using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public class IniFileRepository : IIniFileRepository
    {
        public IniFileRepository()
        {
            
        }

        public Task<Dictionary<string, Dictionary<string, string>>> GetSettings()
        {
            throw new NotImplementedException();
        }
    }
}
