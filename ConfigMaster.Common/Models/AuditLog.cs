using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.Common.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string EventId { get; set; } = string.Empty; // A unique identifier for the event
        public string Action { get; set; } = string.Empty; // The specific action that was performed (e.g., login, file access, configuration change)
        public string Actor { get; set; } = string.Empty; // The user or service account that performed the action
        public string Resource { get; set; } = string.Empty; // The specific resource (e.g., file, application, user account) that was affected
        public string Status { get; set; } = string.Empty; // The outcome of the action (e.g., success, failure)
        public string Location { get; set; } = string.Empty; // The physical or network location from which the action was performed
        public DateTime Created { get; set; }
    }
}
