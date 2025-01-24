using ConfigMaster.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public class PathManagerRepository : IPathManagerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<PathManagerRepository> _logger;

        public PathManagerRepository(AppDbContext dbContext, ILogger<PathManagerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<PathInfo> GetPath()
        {
            try
            {
                var pathInfo = await _dbContext.PathInfo.FirstOrDefaultAsync();
                _logger.LogInformation("Retrieved path information: {PathInfo}", pathInfo);
                return pathInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving path information.");
                throw;
            }
        }

        public async Task AddPath(PathInfo pathInfo)
        {
            try
            {
                await _dbContext.PathInfo.AddAsync(pathInfo);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Added new path information: {PathInfo}", pathInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding path information: {PathInfo}", pathInfo);
                throw;
            }
        }

        public async Task UpdatePath(string path)
        {
            try
            {
                var pathInfo = await _dbContext.PathInfo.FirstOrDefaultAsync();
                if (pathInfo != null)
                {
                    pathInfo.Path = path;
                    _dbContext.PathInfo.Update(pathInfo);
                    await _dbContext.SaveChangesAsync();
                    _logger.LogInformation("Updated path information: {PathInfo}", pathInfo);
                }
                else
                {
                    _logger.LogWarning("No path information found to update.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating path information to: {Path}", path);
                throw;
            }
        }
    }
}
