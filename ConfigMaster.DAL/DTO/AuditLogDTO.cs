using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.DTO
{
    public class AuditLogDTO
    {
        public string EventId { get; set; } = string.Empty;
        public string Actor { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Resource { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}
