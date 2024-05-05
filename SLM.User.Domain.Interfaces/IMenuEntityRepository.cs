using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IMenuEntityRepository
    {   
        Task<IEnumerable<MenuEntity>> GetAllMenuHeaders();
        Task AddNewMenuAsync(MenuEntity menu);
        Task UpdateExistingMenuAsync(MenuEntity menu);
        Task DeleteMenuByMenuIdAsync(string menucode);
    }
}
