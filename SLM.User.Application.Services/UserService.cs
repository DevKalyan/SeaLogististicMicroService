using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.Helpers;
using SLM.User.Application.Utilities.Mappers;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Interfaces;
using SLM.User.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserEntityRepository _userBasicDetailsRepo;
        private readonly IUserCredentialsEntityRepostiory _userCredentialsRepo;
        public UserService(
            IUserEntityRepository userEntityRepository,
            IUserCredentialsEntityRepostiory userCredentialsEntityRepostiory)
        {
            _userBasicDetailsRepo = userEntityRepository;
            _userCredentialsRepo = userCredentialsEntityRepostiory;
        }
        //public Task<IEnumerable<UserViewModel>> GetAdfdfllUserDetails()
        //{
        //    var _userbasicDetails = _userBasicDetailsRepo.GetUserBasicDetailsAsync();
        //    // Implement CredentalDetails Getall Repository and change this funtion

            
        //}

        public Task<IEnumerable<UserViewModel>> GetAllUserDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetUserDetailsByUserId(Guid userid)
        {
            var userBasicDetails = await _userBasicDetailsRepo.GetuserByUserIdAsync(userid);
            var userCredentialsDetails = await _userCredentialsRepo.GetUserCredentialsByUserIdAsync(userid); 
            var convertedUserDetails = UserMapper.ConvertToUserViewModel(userBasicDetails, userCredentialsDetails);
            return convertedUserDetails;

        }

        public async Task<UserViewModel> ValidateUser(string username, string password)
        {
            var userCredentialsDetails = await _userCredentialsRepo.GetUserCredentialsByUsernameAsync(username);

            if (userCredentialsDetails != null)
            {
                // Verify the provided password
                bool isValidPassword =PasswordHelper.VerifyPassword(password, userCredentialsDetails.HashedPassword);

                if (isValidPassword)
                {
                    // Password is valid, retrieve user details
                    var userBasicDetails = await _userBasicDetailsRepo.GetuserByUserIdAsync(userCredentialsDetails.UserId);
                    var convertedUserDetails = UserMapper.ConvertToUserViewModel(userBasicDetails, userCredentialsDetails);
                    return convertedUserDetails;
                }
            }

            // If user does not exist or password is invalid, return null or throw an exception
            return null;
        }
    }
}
