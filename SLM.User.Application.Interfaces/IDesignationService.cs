using SLM.User.Application.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Interfaces
{
    public interface IDesignationService
    {
        Task<List<DesignationViewModel>> GetDesignationsAsync();
        Task InsertNewDesignation(DesignationViewModel desingationDetails);
        Task UpdateExistingDesignation(DesignationViewModel desingationDetails);
        Task DeleteExistingDesignation(Guid designationId);

    }
}
