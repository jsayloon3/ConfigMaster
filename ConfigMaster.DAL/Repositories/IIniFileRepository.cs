using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public interface IIniFileRepository
    {
        Task<Dictionary<string, Dictionary<string, string>>> GetSettings();
    }
}
