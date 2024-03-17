using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IMenuEnttiyRepository
    {   
        Task AddNewDesignationAsync(MenuEntity menu);
        Task UpdateExistingDesignationAsync(MenuEntity menu);
        Task DeleteDesigntationAsync(MenuEntity menu);
    }
}
