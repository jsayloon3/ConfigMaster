using ConfigMaster.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public interface IPathManagerService
    {
        Task<PathInfo> GetPath();
        Task AddPath(PathInfo pathInfo);
        Task UpdatePath(string path);
    }
}
