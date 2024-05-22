using SLM.User.Application.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Interfaces
{
    public interface IUserTypeService
    {
        Task<List<UserTypeViewModel>> GetAllUserTypes();
        Task InsertNewUserType(UserTypeViewModel userType);
        Task UpdateExistingUserType(UserTypeViewModel userType);
        Task DeleteExistingUserType(Guid usertypeId);

    }
}
