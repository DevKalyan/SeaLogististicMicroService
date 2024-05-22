using SLM.User.Application.Utilities.Helpers;
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
    public class UserMapper
    {
        public static UserViewModel ConvertToUserViewModel(UserEntity userentity,
                                                          UserCredentialEntity usercredentialentity,
                                                          UserMenusEntity userallocatedmenus)
        {

            var _lstUserMenu = new List<UserMenuModel>();
            UserBasicDetailsModel _userbasicDetails = new()
            {
                User_FirstName = userentity.Firstname,
                User_MiddleName = userentity.MiddleName,
                User_LastName = userentity.Lastname,
                User_DateOfBirth = userentity.DateOfBirth,
                User_Country = userentity.Country,
                User_PostalCode = userentity.PostalCode,
                User_PhoneNumber = userentity.PhoneNumber,
                User_State = userentity.State,
                User_Email = userentity.Email,
                
            };

            UserCredentialsModel _userCredentials = new()
            {               
                Username = usercredentialentity.Username,
                PasswordHash = usercredentialentity.HashedPassword,
                DtPasswordChanged = usercredentialentity.DtPasswordChanged,
                PasswordChanged = usercredentialentity.PasswordChanged               
            };

            UserMenuModel _userMenuModel = new()
            {
                AssingedMenuCodes = userallocatedmenus.AllocatedMenus,                
            };
            //foreach (var item in userallocatedmenus)
            //{
            //    
            //    _lstUserMenu.Add(_userMenuModel);
            //}           


            UserViewModel _returnuserViewModel = new UserViewModel()
            {
                UserId = userentity.EntityID,
                UserBasicDetails = _userbasicDetails,
                UserCredentials = _userCredentials,
                UserMenuDetails = _userMenuModel                
            };
            return _returnuserViewModel;
        }

        //public static List<UserViewModel> ConvertToUserViewModel(List<UserEntity> userEntities,
        //                                                  List<UserCredentialEntity> userCredentialEntities,
        //                                                  List<UserMenusEntity> userAllocatedMenus)
        //{
        //    var userViewModels = new List<UserViewModel>();

        //    for (int i = 0; i < userEntities.Count; i++)
        //    {
        //        var userEntity = userEntities[i];
        //        var userCredentialEntity = userCredentialEntities[i];
        //        var userAllocatedMenu = userAllocatedMenus[i];

        //        var userBasicDetails = new UserBasicDetailsModel
        //        {
        //            User_FirstName = userEntity.Firstname,
        //            User_MiddleName = userEntity.MiddleName,
        //            User_LastName = userEntity.Lastname,
        //            User_DateOfBirth = userEntity.DateOfBirth,
        //            User_Country = userEntity.Country,
        //            User_PostalCode = userEntity.PostalCode,
        //            User_PhoneNumber = userEntity.PhoneNumber,
        //            User_State = userEntity.State,
        //            User_Email = userEntity.Email,
        //            CreatedDt = userEntity.CreatedAt,
        //            CreateUserId = userEntity.CreatedBy,
        //            ModifiedUserId = userEntity.UpdatedBy,
        //            ModifiedDt = userEntity.UpdatedAt,
        //            IsDeleted = userEntity.IsDeleted,
        //            UniqueID = userEntity.EntityID
        //        };

        //        var userCredentials = new UserCredentialsModel
        //        {
        //            UniqueID = userEntity.EntityID,
        //            Username = userCredentialEntity.Username,
        //            PasswordHash = userCredentialEntity.HashedPassword,
        //            DtPasswordChanged = userCredentialEntity.DtPasswordChanged,
        //            PasswordChanged = userCredentialEntity.PasswordChanged,
        //            IsDeleted = userCredentialEntity.IsDeleted,
        //            CreatedDt = userCredentialEntity.CreatedAt,
        //            CreateUserId = userCredentialEntity.CreatedBy,
        //            ModifiedUserId = userCredentialEntity.UpdatedBy,
        //            ModifiedDt = userCredentialEntity.UpdatedAt
        //        };

        //        var userMenuDetails = userAllocatedMenu.Select(menu => new UserMenuModel
        //        {
        //            AssingedMenuCodes = menu.MenuCode,
        //            //UserId = menu.UserId
        //        }).ToList();

        //        var userViewModel = new UserViewModel
        //        {
        //            UserId = userEntity.EntityID,
        //            UserBasicDetails = userBasicDetails,
        //            UserCredentials = userCredentials,
        //            UserMenuDetails = userMenuDetails
        //        };

        //        userViewModels.Add(userViewModel);
        //    }

        //    return userViewModels;
        //}


        public static UserEntity ConvertUserViewModelToUserEntity(UserViewModel userViewModel)
        {
            UserEntity userBasicDetails = new()
            {
                Firstname = userViewModel.UserBasicDetails.User_FirstName,
                MiddleName = userViewModel.UserBasicDetails.User_MiddleName,
                Lastname = userViewModel.UserBasicDetails.User_LastName,
                Country = userViewModel.UserBasicDetails.User_Country,
                DateOfBirth = userViewModel.UserBasicDetails.User_DateOfBirth,
                DesignationId = userViewModel.UserBasicDetails.User_Designation,                
                Email = userViewModel.UserBasicDetails.User_Email,
                EntityID = userViewModel.UserId,
                //IsDeleted= userViewModel.
                PhoneNumber = userViewModel.UserBasicDetails.User_PhoneNumber,
                PostalCode = userViewModel.UserBasicDetails.User_PhoneNumber,
                State = userViewModel.UserBasicDetails.User_State,
                UserTypeId = userViewModel.UserBasicDetails.User_Type,
                CreatedAt = userViewModel.CreatedAt,
                CreatedBy = userViewModel.CreatedBy,
                UpdatedAt = userViewModel.UpdatedAt,
                UpdatedBy = userViewModel.UpdatedBy,                
            };
            return userBasicDetails;
        }
        public static UserCredentialEntity ConvertUserViewModelToUserCredentialEntity(UserViewModel userViewModel)
        {
            UserCredentialEntity userCredDetails = new()            {
               
                DtPasswordChanged = userViewModel.UserCredentials.DtPasswordChanged,
                HashedPassword = PasswordHelper.HashPassword(userViewModel.UserCredentials.PasswordHash),
                PasswordChanged = userViewModel.UserCredentials.PasswordChanged,
                UserId = userViewModel.UserId,
                CreatedAt = userViewModel.CreatedAt,
                CreatedBy = userViewModel.CreatedBy,
                UpdatedAt = userViewModel.UpdatedAt,
                UpdatedBy = userViewModel.UpdatedBy

            };
            return userCredDetails;
        }
        public static UserMenusEntity ConvertUserViewModelToUserMenuEntity(UserViewModel userViewModel)
        {
            var _lstUserMenus = new List<UserMenusEntity>();

            UserMenusEntity userMenuDetails = new()
            {
                //EntityID = userViewModel.,
                UserId = userViewModel.UserId,
                AllocatedMenus = userViewModel.UserMenuDetails.AssingedMenuCodes,
                CreatedAt = userViewModel.CreatedAt,
                CreatedBy = userViewModel.CreatedBy,
                UpdatedAt = userViewModel.UpdatedAt,
                UpdatedBy = userViewModel.UpdatedBy
            };
            return userMenuDetails;
        }
    }
}
