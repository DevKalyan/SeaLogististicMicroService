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
    public class MenuItemEntityRepository : IMenuItemsEntityRepository
    {
        private readonly UserManagementContext _localuserManagmentContext;
        public MenuItemEntityRepository(UserManagementContext context)
        {
            _localuserManagmentContext = context;
        }
        public async Task AddNewMenuItemAsync(MenuItemsEntity menuitems)
        {
            await _localuserManagmentContext.MenuItems.AddAsync(menuitems);
            _ = _localuserManagmentContext.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(string parentmenucode, string menuitemcode)
        {
            var result = await _localuserManagmentContext.MenuItems.FirstOrDefaultAsync(e => e.ParentMenuCode == parentmenucode && e.MenuItemCode== menuitemcode);
            if (result != null)
            {
                _localuserManagmentContext.MenuItems.Remove(result);
                await _localuserManagmentContext.SaveChangesAsync();
            }
        }

        public async Task UpdateExistingMenuItemAsync(MenuItemsEntity MenuItems)
        {
            _localuserManagmentContext.MenuItems.Update(MenuItems);
            await _localuserManagmentContext.SaveChangesAsync();
        }
    }
}
