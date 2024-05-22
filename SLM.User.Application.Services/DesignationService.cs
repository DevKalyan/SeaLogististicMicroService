using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.Mappers;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationEntityRepository _repo;

        public DesignationService(
            IDesignationEntityRepository designationRepo)
        {
            _repo = designationRepo;
        }

        public async Task DeleteExistingDesignation(Guid designationId)
        {
            var _designationDetails = await _repo.GetDesignationDetailsForDesignationIdAsync(designationId);
            if (_designationDetails != null)
            {
                await _repo.DeleteDesigntationAsync(designationId);
            }
        }

        public async Task<List<DesignationViewModel>> GetDesignationsAsync()
        {
            var _designationList = await _repo.GetAllDesignationsAsync();
            return DesignationMapper.ConvertDesignationEntityToDesignationViewModel(_designationList);
        }

        public Task InsertNewDesignation(DesignationViewModel desingationDetails)
        {
            var _designationEntity = DesignationMapper.ConvertDesignationViewModelToDesignationEntity(desingationDetails);
           return  _repo.AddNewDesignationAsync(_designationEntity);
        }

        public async Task UpdateExistingDesignation(DesignationViewModel desingationDetails)
        {
            var _designationDetails = await _repo.GetDesignationDetailsForDesignationIdAsync(desingationDetails.PrimaryId);

            if (_designationDetails != null)
            {                
                await _repo.UpdateExistingDesignationAsync(_designationDetails);
            }
        }
    }
}
