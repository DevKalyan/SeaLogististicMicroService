using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IDesignationEntityRepository
    {
        Task<DesignationEntity> GetDesignationDetailsForUserAsync(Guid designationid);
        Task<List<DesignationEntity>> GetAllDesignationsAsync();
        Task AddNewDesignationAsync(DesignationEntity designation);
        Task UpdateExistingDesignationAsync(DesignationEntity designation);
        Task DeleteDesigntationAsync(Guid designationid);
    }
}
