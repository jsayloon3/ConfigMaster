using ConfigMaster.BLL.Session;
using ConfigMaster.Common.Enums;
using ConfigMaster.Common.Models;
using ConfigMaster.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public class AuditTrailManagerService : IAuditTrailManagerService
    {
        private readonly IPathManagerService _pathManagerService;
        private readonly IAuditTrailManagerRepository _auditTrailManagerRepository;
        private readonly IUserRepository _userRepository;
        private readonly SessionManager _sessionManager;

        public AuditTrailManagerService(
            IPathManagerService pathManagerService,
            IAuditTrailManagerRepository auditTrailManagerRepository,
            IUserRepository userRepository,
            SessionManager sessionManager)
        {
            _pathManagerService = pathManagerService;
            _auditTrailManagerRepository = auditTrailManagerRepository;
            _userRepository = userRepository;
            _sessionManager = sessionManager;
        }

        public async Task AddLog(string message, AuditTrail.ActionType actionType, string status)
        {
            string eventId = $"{Guid.NewGuid().ToString("N").Substring(0, 8)}-{DateTime.UtcNow.ToString("yyyyMMdd", CultureInfo.InvariantCulture)}";
            var currentSession = _sessionManager.GetSession();
            if (currentSession == null)
            {
                throw new InvalidOperationException("No active session found.");
            }

            var user = await _userRepository.GetUserByUsername(currentSession.UserName);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var pathInfo = await _pathManagerService.GetPath();
            if (pathInfo == null)
            {
                throw new InvalidOperationException("Path information not found.");
            }

            AuditLog auditLog = new()
            {
                EventId = eventId,
                Action = actionType.ToString(),
                Message = message,
                Actor = user.UserName,
                Resource = Path.GetFileName(pathInfo.Path),
                Status = status,
                Location = pathInfo.Path,
                Created = DateTime.Now,
            };

            await _auditTrailManagerRepository.AddLog(auditLog);
        }

        public Task<List<AuditLog>> GetAuditLogs()
        {
            return _auditTrailManagerRepository.GetAllAuditLog();
        }

        public Task<List<AuditLog>> GetAuditLogsByDate(DateTime date)
        {
            return _auditTrailManagerRepository.GetAuditLogByCreatedDate(date);
        }
    }
}
