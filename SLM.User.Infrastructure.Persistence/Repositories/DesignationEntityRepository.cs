using Microsoft.EntityFrameworkCore;
using SLM.User.Domain.Entities.Models;
using SLM.User.Domain.Interfaces;
using SLM.User.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Repositories
{
    public class DesignationEntityRepository : IDesignationEntityRepository
    {
        private readonly UserManagementContext _localuserManagmentContext;
        public DesignationEntityRepository(UserManagementContext context)
        {
            _localuserManagmentContext = context;
        }

        public async Task AddNewDesignationAsync(DesignationEntity designation)
        {
            await _localuserManagmentContext.Designations.AddAsync(designation);
            _ = _localuserManagmentContext.SaveChangesAsync();
        }

        public async Task DeleteDesigntationAsync(Guid designationid)
        {
            var result = await _localuserManagmentContext.Designations.FirstOrDefaultAsync(e => e.EntityID == designationid);
            if (result != null)
            {
                //_localuserManagmentContext.Designations.Remove(result);
                result.IsDeleted = 1;
                await _localuserManagmentContext.SaveChangesAsync();
            }
        }

        public async Task<List<DesignationEntity>> GetAllDesignationsAsync()
        {
            var result = await _localuserManagmentContext.Designations.ToListAsync();
            return result;
        }

        public async Task<DesignationEntity> GetDesignationDetailsForDesignationIdAsync(Guid designationid)
        {
            var _userBasicDetails = await _localuserManagmentContext.Designations.Where(u => u.EntityID == designationid).FirstOrDefaultAsync();
            return _userBasicDetails;
        }

        public async Task UpdateExistingDesignationAsync(DesignationEntity designation)
        {
            _localuserManagmentContext.Designations.Update(designation);
            await _localuserManagmentContext.SaveChangesAsync();
        }
    }

}

