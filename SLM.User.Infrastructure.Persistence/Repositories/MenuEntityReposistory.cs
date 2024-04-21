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
    public class MenuEntityReposistory : IMenuEntityRepository
    {
        private readonly UserManagementContext _localuserManagmentContext;
        public MenuEntityReposistory(UserManagementContext context)
        {
            _localuserManagmentContext = context;
        }

        public async Task AddNewMenuAsync(MenuEntity menu)
        {
            await _localuserManagmentContext.Menus.AddAsync(menu);
            _ = _localuserManagmentContext.SaveChangesAsync();
        }

        public async Task DeleteMenuByMenuIdAsync(string menucode)
        {
            var result = await _localuserManagmentContext.Menus.FirstOrDefaultAsync(e => e.MenuCode == menucode);
            if (result != null)
            {
                _localuserManagmentContext.Menus.Remove(result);
                await _localuserManagmentContext.SaveChangesAsync();
            }
        }

        public async Task UpdateExistingMenuAsync(MenuEntity menu)
        {
            _localuserManagmentContext.Menus.Update(menu);
            await _localuserManagmentContext.SaveChangesAsync();
        }
    }
}
