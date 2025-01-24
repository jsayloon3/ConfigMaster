using ConfigMaster.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public interface IAuditTrailManagerRepository
    {
        Task<List<AuditLog>> GetAllAuditLog();
        Task<AuditLog> GetAuditLogByCreatedDate(DateTime createdDate);
        Task AddLog(AuditLog log);
    }
}
