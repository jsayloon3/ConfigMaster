using ConfigMaster.BLL.Services;
using ConfigMaster.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.Defaults
{
    public class AddDefaultConfigurationPath
    {
        private readonly IPathManagerService _pathManagerService;
        public AddDefaultConfigurationPath(IPathManagerService pathManagerService)
        {
            _pathManagerService = pathManagerService;
        }

        public async Task<bool> IsPathEmpty()
        {
            return await _pathManagerService.GetPath() == null;
        }

        public async Task AddDefaultPath()
        {
            var pathInfo = new Common.Models.PathInfo
            {
                Id = 1,
                Path = @"C:\BarterCX\BARTER_CX.ini",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _pathManagerService.AddPath(pathInfo);
        }
    }
}
