using ConfigMaster.Common.Models;
using ConfigMaster.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IUserRepository _userRepository;
        public UserManagerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<bool> HasUser()
        {
            var users = await _userRepository.GetUsers();
            return users.Count > 0;
        }
    }
}
