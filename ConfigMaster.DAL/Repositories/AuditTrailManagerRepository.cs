using ConfigMaster.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public class AuditTrailManagerRepository : IAuditTrailManagerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<AuditTrailManagerRepository> _logger;

        public AuditTrailManagerRepository(AppDbContext dbContext, ILogger<AuditTrailManagerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddLog(AuditLog log)
        {
            try
            {
                _dbContext.AuditLogs.Add(log);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Audit log added successfully: {@Log}", log);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an audit log: {@Log}", log);
                throw;
            }
        }

        public async Task<List<AuditLog>> GetAllAuditLog()
        {
            try
            {
                var logs = await _dbContext.AuditLogs.ToListAsync();
                _logger.LogInformation("Retrieved all audit logs successfully.");
                return logs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all audit logs.");
                throw;
            }
        }

        public async Task<AuditLog> GetAuditLogByCreatedDate(DateTime createdDate)
        {
            try
            {
                var log = await _dbContext.AuditLogs
                    .Where(log => log.Created.Date == createdDate.Date)
                    .FirstOrDefaultAsync();
                _logger.LogInformation("Retrieved audit log by created date successfully: {@CreatedDate}", createdDate);
                return log;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving an audit log by created date: {@CreatedDate}", createdDate);
                throw;
            }
        }
    }
}
