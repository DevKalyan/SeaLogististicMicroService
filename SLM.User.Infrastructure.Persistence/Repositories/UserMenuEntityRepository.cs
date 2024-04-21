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
    public class UserMenuEntityRepository : IUserMenuEntityRepository
    {
        private readonly UserManagementContext _localuserManagmentContext;
        public UserMenuEntityRepository(UserManagementContext context) 
        {
            _localuserManagmentContext = context;
        }

        public async Task AddAllocatedMenusForUserAsync(UserMenusEntity usermenu)
        {
            await _localuserManagmentContext.UserMenus.AddAsync(usermenu);
            _ = _localuserManagmentContext.SaveChangesAsync();
        }

        public async Task DeleteAllocatedMenusForUserAsync(Guid userid)
        {
            var result = await _localuserManagmentContext.UserMenus.FirstOrDefaultAsync(e => e.UserId == userid);
            if (result != null)
            {
                _localuserManagmentContext.UserMenus.Remove(result);
                await _localuserManagmentContext.SaveChangesAsync();
            }
        }
        public async Task UpdateAllocatedMenusForUserAsync(UserMenusEntity usermenu)
        {
            _localuserManagmentContext.UserMenus.Update(usermenu);
            await _localuserManagmentContext.SaveChangesAsync(); ;
        }

        Task<UserMenusEntity> IUserMenuEntityRepository.GetAllocatedMenusForUser(Guid userid)
        {
            throw new NotImplementedException();
        }
    }
}
