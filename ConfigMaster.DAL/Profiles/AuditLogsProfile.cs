using AutoMapper;
using ConfigMaster.Common.Models;
using ConfigMaster.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Profiles
{
    public class AuditLogsProfile : Profile
    {
        public AuditLogsProfile()
        {
            CreateMap<AuditLog, AuditLogDTO>();
        }
    }
}
