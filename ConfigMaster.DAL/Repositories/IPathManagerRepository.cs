using ConfigMaster.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public interface IPathManagerRepository
    {
        Task<PathInfo> GetPath();
        Task UpdatePath(string path);
    }
}
