using ConfigMaster.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Added new user: {UserName}", user.UserName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new user: {UserName}", user.UserName);
                throw;
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            try
            {
                var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username);
                if (user != null)
                {
                    _logger.LogInformation("Retrieved user by username: {UserName}", username);
                }
                else
                {
                    _logger.LogWarning("User not found by username: {UserName}", username);
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user by username: {UserName}", username);
                throw;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users.");
                throw;
            }
        }
    }
}
