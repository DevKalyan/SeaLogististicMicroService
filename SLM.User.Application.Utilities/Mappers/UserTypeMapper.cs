using SLM.User.Application.Utilities.Models;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.Mappers
{
    public class UserTypeMapper
    {
        public static List<UserTypeViewModel> ConvertUserTypeEntityToUserTypeViewModel(List<UserTypeEntity> userTypeEntity)
        {
            List<UserTypeViewModel> listuserTypes = new();

            foreach (var item in userTypeEntity)
            {
                UserTypeViewModel userTypeViewModel = new UserTypeViewModel
                {
                    UserTypeName = item.TypeName,
                    UserTypeDesription = item.Description,
                    PrimaryId = item.EntityID,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    UpdatedBy = item.UpdatedBy
                };                
                listuserTypes.Add(userTypeViewModel);
            }
            return listuserTypes;
        }
        public static UserTypeViewModel ConvertUserTypeEntityToUserTypeViewModel(UserTypeEntity userTypeEntity)
        {
            UserTypeViewModel userTypeViewModel = new UserTypeViewModel
            {
                UserTypeName = userTypeEntity.TypeName,
                UserTypeDesription = userTypeEntity.Description,
                PrimaryId = userTypeEntity.EntityID,
                CreatedAt = userTypeEntity.CreatedAt,
                UpdatedAt = userTypeEntity.UpdatedAt,
                UpdatedBy = userTypeEntity.UpdatedBy
            };

            return userTypeViewModel;
        }
        public static UserTypeEntity ConvertUserTypeViewModelToUserTypeEntity(UserTypeViewModel userTypeViewModel)
        {
            UserTypeEntity userTypeEntity = new()
            {
                TypeName = userTypeViewModel.UserTypeName,
                Description = userTypeViewModel.UserTypeDesription,
                EntityID = userTypeViewModel.PrimaryId,
                CreatedAt = userTypeViewModel.CreatedAt,
                UpdatedAt = userTypeViewModel.UpdatedAt,
                UpdatedBy = userTypeViewModel.UpdatedBy
            };

            return userTypeEntity;
        }
    }
}
