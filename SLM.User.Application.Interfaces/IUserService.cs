using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> ValidateUser(string username, string password);
        Task<UserViewModel> GetUserDetailsByUserId(Guid userid);
        Task<IEnumerable<List<UserViewModel>>> GetAllUserDetails();
        Task InsertNewUserDetails(UserViewModel newUserDetails);
    }
}
