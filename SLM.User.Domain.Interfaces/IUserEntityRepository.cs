using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IUserEntityRepository
    {
        Task<UserEntity> GetuserByUserIdAsync(Guid userid);
        Task<List<UserEntity>> GetUserBasicDetailsAsync();
        Task AddUserBasicDetailsAsync(UserEntity user);
        Task UpdateUserBasicDetailsAsync(UserEntity user);
        Task DeleteUserBasicDetailsAsync(UserEntity user);
    }
}
