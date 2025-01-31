using ConfigMaster.Common.Enums;
using ConfigMaster.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public interface IAuditTrailManagerService
    {
        Task<List<AuditLog>> GetAuditLogs();
        Task<List<AuditLog>> GetAuditLogsByDate(DateTime date);
        Task AddLog(string message, AuditTrail.ActionType actionType, string status);
    }
}
