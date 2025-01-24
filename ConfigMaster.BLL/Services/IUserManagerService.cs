using ConfigMaster.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public interface IUserManagerService
    {
        Task<List<User>> GetUsers();
        Task<bool> HasUser();
    }
}
