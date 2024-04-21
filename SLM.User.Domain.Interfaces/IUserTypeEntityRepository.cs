using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IUserTypeEntityRepository
    {
        Task<UserTypeEntity> GetUserTypeForUserAsync(Guid userid);
        Task<List<UserTypeEntity>> GetAllUserTypesAsync();
        Task AddNewUserTypeAsync(UserTypeEntity user);
        Task UpdateExistingUsertypeAsync(UserTypeEntity user);
        Task DeleteUserTypeAsync(Guid usertypeid);
    }
}
