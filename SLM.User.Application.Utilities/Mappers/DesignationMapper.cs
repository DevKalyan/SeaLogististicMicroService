using SLM.User.Application.Utilities.Models;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Entities.Models;

namespace SLM.User.Application.Utilities.Mappers
{
    public class DesignationMapper
    {
        public static List<DesignationViewModel> ConvertDesignationEntityToDesignationViewModel(List<DesignationEntity> designationentity)
        {
            List<DesignationViewModel> listDesignation = new List<DesignationViewModel>();

            foreach (var item in designationentity)
            {
                DesignationViewModel designationViewModel = new DesignationViewModel();

                designationViewModel.Title = item.Title;
                designationViewModel.Description = item.Description;
                designationViewModel.PrimaryId = item.EntityID;
                designationViewModel.CreatedAt = item.CreatedAt;
                designationViewModel.CreatedBy = item.CreatedBy;
                designationViewModel.UpdatedAt = item.UpdatedAt;
                designationViewModel.UpdatedBy = item.UpdatedBy;
                designationViewModel.UpdatedAt = item.UpdatedAt;
                listDesignation.Add(designationViewModel);
            }
            return listDesignation;
        }
        public static DesignationViewModel ConvertDesignationEntityToDesignationViewModel(DesignationEntity designationentity)
        {
            DesignationViewModel designationViewModel = new()
            {
                Title = designationentity.Title,
                Description = designationentity.Description,
                PrimaryId = designationentity.EntityID,
                CreatedAt = designationentity.CreatedAt,
                UpdatedAt = designationentity.UpdatedAt,
                UpdatedBy = designationentity.UpdatedBy,
                 CreatedBy = designationentity.CreatedBy
            };

            return designationViewModel;
        }
        public static DesignationEntity ConvertDesignationViewModelToDesignationEntity(DesignationViewModel designationentity)
        {
            DesignationEntity designationViewModel = new()
            {
                Title = designationentity.Title,
                Description = designationentity.Description,
                EntityID = designationentity.PrimaryId,
                CreatedAt = designationentity.CreatedAt,
                UpdatedAt = designationentity.UpdatedAt,
                UpdatedBy = designationentity.UpdatedBy,
               CreatedBy= designationentity.CreatedBy            
            };

            return designationViewModel;
        }
    }
}
