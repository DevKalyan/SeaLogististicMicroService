using Microsoft.EntityFrameworkCore;
using SLM.User.Domain.Entities.Models;
using SLM.User.Domain.Interfaces;
using SLM.User.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Repositories
{
    public class UserCredentialsEntityRepository : IUserCredentialsEntityRepostiory
    {

        private readonly UserManagementContext _localuserManagmentContext;
        public UserCredentialsEntityRepository(UserManagementContext context)
        {
            _localuserManagmentContext = context;
        }

        public async Task AddUserCredentialDetailsAsync(UserCredentialEntity user)
        {
            await _localuserManagmentContext.UserCredentials.AddAsync(user);
            _ = _localuserManagmentContext.SaveChanges();
        }

        public async Task DeleteUserCredentialDetailsAsync(UserCredentialEntity user)
        {
            var result = await _localuserManagmentContext.UserCredentials.FirstOrDefaultAsync(e => e.UserId == user.EntityID);
            if (result != null)
            {
                _localuserManagmentContext.UserCredentials.Remove(result);
                await _localuserManagmentContext.SaveChangesAsync();
            }
        }

        public async Task<UserCredentialEntity> GetUserCredentialsByUserIdAsync(Guid userid)
        {
            var result = await _localuserManagmentContext.UserCredentials.FirstOrDefaultAsync(e => e.UserId == userid);
            return result;
        }

        public async Task<UserCredentialEntity> GetUserCredentialsByUsernameAsync(string username)
        {
            var result = await _localuserManagmentContext.UserCredentials.FirstOrDefaultAsync(e => e.Username == username);
            return result;
        }

        public async Task UpdateUserCredentialDetailsAsync(UserCredentialEntity user)
        {
            _localuserManagmentContext.UserCredentials.Update(user);
            await _localuserManagmentContext.SaveChangesAsync();
        }

        public async Task<UserCredentialEntity> ValidateUser(string username, string password)
        {
            var result = await _localuserManagmentContext.UserCredentials
                .FirstOrDefaultAsync(e => e.Username ==username && e.HashedPassword== password);
            return result;
        }
    }
}
