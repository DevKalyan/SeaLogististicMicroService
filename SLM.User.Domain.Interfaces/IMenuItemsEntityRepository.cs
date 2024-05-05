using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IMenuItemsEntityRepository
    {
        Task<IEnumerable<MenuItemsEntity>> GetAllMenuItems();
        Task AddNewMenuItemAsync(MenuItemsEntity menuitems);
        Task UpdateExistingMenuItemAsync(MenuItemsEntity menuitems);
        Task DeleteMenuItemAsync(string  parentmenucode, string menuitemcode);
    }
}
