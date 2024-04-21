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
        public static UserViewModel ConvertToUserViewModel(UserEntity userentity, UserCredentialEntity usercredentialentity)
        {
            UserBasicDetailsModel _userbasicDetails = new UserBasicDetailsModel()
            {
                User_FirstName=userentity.Firstname,
                User_MiddleName=userentity.MiddleName,
                User_LastName=userentity.Lastname,
                User_DateOfBirth=userentity.DateOfBirth,                
                User_Country = userentity.Country,
                User_PostalCode=userentity.PostalCode,
                User_PhoneNumber=userentity.PhoneNumber,
                User_State=userentity.State,
                User_Email = userentity.Email,
                CreatedDt= userentity.CreatedAt,
                CreateUserId=userentity.CreatedBy,
                ModifiedUserId= userentity.UpdatedBy,
                UpdatedDt= userentity.UpdatedAt,
                IsDeleted= userentity.IsDeleted,
                UniqueID= userentity.EntityID
            };

            UserCredentialsModel _userCredentials = new UserCredentialsModel()
            {
                UniqueID= userentity.EntityID,
                Username= usercredentialentity.Username,
                PasswordHash= usercredentialentity.HashedPassword,
                DtPasswordChanged=usercredentialentity.DtPasswordChanged,
                PasswordChanged=usercredentialentity.PasswordChanged,                                
                IsDeleted = usercredentialentity.IsDeleted,
                CreatedDt = usercredentialentity.CreatedAt,
                CreateUserId = usercredentialentity.CreatedBy,
                ModifiedUserId = usercredentialentity.UpdatedBy,
                UpdatedDt = usercredentialentity.UpdatedAt
            };

            UserViewModel _returnuserViewModel = new UserViewModel()
            {
             UserId = userentity.EntityID,
              UserBasicDetails = _userbasicDetails,
              UserCredentials =_userCredentials
            };
            return _returnuserViewModel;
        }
    }
}
