using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IUserCredentialsEntityRepostiory
    {
        Task<UserCredentialEntity> ValidateUser(string username,string password);
        //Task<List<UserEntity>> GetUserBasicDetailsAsync();
        Task AddUserCredentialDetailsAsync(UserCredentialEntity user);
        Task UpdateUserCredentialDetailsAsync(UserCredentialEntity user);
        Task DeleteUserCredentialDetailsAsync(UserCredentialEntity user);

    }
}
