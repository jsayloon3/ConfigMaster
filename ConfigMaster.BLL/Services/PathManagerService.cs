using ConfigMaster.Common.Models;
using ConfigMaster.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public class PathManagerService : IPathManagerService
    {
        private readonly IPathManagerRepository _pathManagerRepository;
        public PathManagerService(IPathManagerRepository pathManagerRepository)
        {
            _pathManagerRepository = pathManagerRepository;
        }

        public async Task AddPath(PathInfo pathInfo)
        {
           await _pathManagerRepository.AddPath(pathInfo);
        }

        public async Task<PathInfo> GetPath()
        {
            return await _pathManagerRepository.GetPath();
        }

        public async Task UpdatePath(string path)
        {
            await _pathManagerRepository.UpdatePath(path);
        }
    }
}
