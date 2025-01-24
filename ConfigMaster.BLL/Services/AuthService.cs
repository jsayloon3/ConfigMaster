using ConfigMaster.DAL.Repositories;
using ConfigMaster.Common.Helpers;
using ConfigMaster.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUser(string username, string password, int roleId)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user != null)
                throw new Exception("Username already exist.");

            // Hash password with salt
            string salt = Security.GenerateSalt();
            string passwordHash = Security.HashPassword(password, salt);

            user = new User { UserName = username, PasswordHash =  passwordHash, RoleId = roleId, PasswordSalt = salt, UserRegistered = DateTime.Now};
            await _userRepository.AddUser(user);
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user is null) return false;

            string passwordHash = Security.HashPassword(password, user.PasswordSalt);
            return passwordHash == user.PasswordHash;
        }
    }
}
