using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IUserMenuEntityRepository
    {
        Task<UserMenusEntity> GetAllocatedMenusForUserAsync(Guid userid);
        //Task<List<UserEntity>> GetUserBasicDetailsAsync();
        Task AddAllocatedMenusForUserAsync(UserMenusEntity user);
        Task UpdateAllocatedMenusForUserAsync(UserMenusEntity user);
        Task DeleteAllocatedMenusForUserAsync(UserMenusEntity user);
    }
}
