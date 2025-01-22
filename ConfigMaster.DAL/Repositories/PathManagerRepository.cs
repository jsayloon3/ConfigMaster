using ConfigMaster.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public class PathManagerRepository : IPathManagerRepository
    {
        private readonly AppDbContext _dbContext;
        public PathManagerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPath(PathInfo pathInfo)
        {
            _dbContext.PathInfo.Add(pathInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PathInfo?> GetPath()
        {
            return await _dbContext.PathInfo.SingleOrDefaultAsync(x => x.Id == 1);
        }
        public async Task UpdatePath(string path)
        {
            var existingPath = _dbContext.PathInfo.SingleOrDefault(x => x.Id == 1);
            if (existingPath != null)
            {
                existingPath.Path = path;
                existingPath.UpdatedAt = DateTime.Now;
                _dbContext.Entry(existingPath).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
