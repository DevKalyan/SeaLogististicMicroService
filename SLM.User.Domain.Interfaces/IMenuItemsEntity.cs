using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IMenuItemsEntity
    {
        Task AddNewDesignationAsync(MenuItemsEntity menuitems);
        Task UpdateExistingDesignationAsync(MenuItemsEntity menuitems);
        Task DeleteDesigntationAsync(MenuItemsEntity menuitems);
    }
}
