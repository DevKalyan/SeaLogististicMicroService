using SLM.User.Application.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuViewModel>> GetAllMenuAsync();

        Task<IEnumerable<MenuViewModel>> GetAllMenuAssignedforUser(Guid userid);
    }
}
