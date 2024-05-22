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
    public class UserEntityRepository : IUserEntityRepository
    {

        private readonly UserManagementContext _localuserManagmentContext;
        public UserEntityRepository(UserManagementContext context)
        {
            _localuserManagmentContext = context;
        }
        public async Task AddUserBasicDetailsAsync(UserEntity user)
        {
            await _localuserManagmentContext.Users.AddAsync(user);
            _ = _localuserManagmentContext.SaveChanges();
        }

        public async Task DeleteUserBasicDetailsAsync(UserEntity user)
        {
            var result = await _localuserManagmentContext.Users.FirstOrDefaultAsync(e => e.EntityID == user.EntityID);
            if (result != null)
            {
                _localuserManagmentContext.Users.Remove(result);
                await _localuserManagmentContext.SaveChangesAsync();
            }
        }

        public async Task<List<UserEntity>> GetUserBasicDetailsAsync()
        {
            var _allUserBasicDetails = await _localuserManagmentContext.Users.ToListAsync();
            return _allUserBasicDetails;
        }

        public async Task<UserEntity> GetuserByUserIdAsync(Guid userid)
        {
            var _userBasicDetails = await _localuserManagmentContext.Users.Where(u => u.EntityID == userid).FirstOrDefaultAsync();
            return _userBasicDetails;
        }

        public async Task UpdateUserBasicDetailsAsync(UserEntity user)
        {
            _localuserManagmentContext.Users.Update(user);
            await _localuserManagmentContext.SaveChangesAsync();
        }
    }
}
