using ConfigMaster.BLL.Services;
using ConfigMaster.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.Defaults
{
    public class AddDefaultUsers
    {
        private readonly IAuthService _authService;
        private readonly IUserManagerService _userManagerService;
        public AddDefaultUsers(IAuthService authService, IUserManagerService userManagerService)
        {
            _authService = authService;
            _userManagerService = userManagerService;
        }

        public async Task<bool> HasUser()
        {
            return await _userManagerService.HasUser();
        }

        public async Task Register()
        {
            var defaultUsers = new List<(string Username, string Password, int RoleId)>
            {
                ("iamproject", "@ConfigProject", 1), // Project manager
                ("iamdeveloper", "@ConfigDeveloper", 2), // Developer
                ("iamqa", "@ConfigQA", 3), // QA
                ("iamtechsupport", "@ConfigTechSupport", 4) // Tech Support
            };

            foreach (var defaultUser in defaultUsers)
            {
                await _authService.RegisterUser(defaultUser.Username, defaultUser.Password, defaultUser.RoleId);
            }
        }
    }
}
