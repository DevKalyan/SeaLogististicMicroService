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
    public class UserTypeEntityRepository : IUserTypeEntityRepository
    {
        private readonly UserManagementContext _localuserManagmentContext;
        public UserTypeEntityRepository(UserManagementContext context)
        {
            _localuserManagmentContext = context;
        }

        public async Task AddNewUserTypeAsync(UserTypeEntity usertype)
        {
            await _localuserManagmentContext.UserTypes.AddAsync(usertype);
            _ = _localuserManagmentContext.SaveChangesAsync();
        }

        public async Task DeleteUserTypeAsync(Guid usertypeid)
        {
            var result = await _localuserManagmentContext.UserTypes.FirstOrDefaultAsync(e => e.EntityID == usertypeid);
            if (result != null)
            {
                _localuserManagmentContext.UserTypes.Remove(result);
                await _localuserManagmentContext.SaveChangesAsync();
            }
        }

        public async Task<List<UserTypeEntity>> GetAllUserTypesAsync()
        {
            var _allUserBasicDetails = await _localuserManagmentContext.UserTypes.ToListAsync();
            return _allUserBasicDetails;
        }

        public Task<UserTypeEntity> GetUserTypeForUserAsync(Guid userid)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateExistingUsertypeAsync(UserTypeEntity user)
        {
            _localuserManagmentContext.UserTypes.Update(user);
            await _localuserManagmentContext.SaveChangesAsync();
        }
    }
}
