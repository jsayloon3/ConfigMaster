using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(string username, string password);
        Task RegisterUser(string username, string password, int roleId);
    }
}
