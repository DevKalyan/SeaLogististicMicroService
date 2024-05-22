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
using System.Transactions;

namespace SLM.User.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserEntityRepository _userBasicDetailsRepo;
        private readonly IUserCredentialsEntityRepostiory _userCredentialsRepo;
        private readonly IUserMenuEntityRepository _userMenuEntityRepo;
        public UserService(
            IUserEntityRepository userEntityRepository,
            IUserCredentialsEntityRepostiory userCredentialsEntityRepostiory,
            IUserMenuEntityRepository userMenuEntityRepostiory
            )
        {
            _userBasicDetailsRepo = userEntityRepository;
            _userCredentialsRepo = userCredentialsEntityRepostiory;
            _userMenuEntityRepo = userMenuEntityRepostiory;
        }
        //public Task<IEnumerable<UserViewModel>> GetAdfdfllUserDetails()
        //{
        //    var _userbasicDetails = _userBasicDetailsRepo.GetUserBasicDetailsAsync();
        //    // Implement CredentalDetails Getall Repository and change this funtion


        //}

        public async Task<IEnumerable<List<UserViewModel>>> GetAllUserDetails()
        {
            // Fetch user entities from repository
            var userEntities = await _userBasicDetailsRepo.GetUserBasicDetailsAsync(); // Assuming GetAll method is available in IUserEntityRepository

            var allUserViewModels = new List<List<UserViewModel>>();

            foreach (var userEntity in userEntities)
            {
                // Fetch user credentials for each user
                var userCredentialEntity = await _userCredentialsRepo.GetUserCredentialsByUserIdAsync(userEntity.EntityID); // Assuming GetByUserId method is available in IUserCredentialsEntityRepostiory

                // Fetch user menu details for each user
                var userAllocatedMenus = await _userMenuEntityRepo.GetAllocatedMenusForUser(userEntity.EntityID); // Assuming GetMenusByUserId method is available in IUserMenuEntityRepository

                // Convert entities to view models
                var userViewModel = UserMapper.ConvertToUserViewModel(userEntity, userCredentialEntity, userAllocatedMenus);

                // Add user view model to the list
                var userViewModelList = new List<UserViewModel> { userViewModel };
                allUserViewModels.Add(userViewModelList);
            }

            return allUserViewModels;
        }


        public async Task<UserViewModel> GetUserDetailsByUserId(Guid userid)
        {
            var userBasicDetails = await _userBasicDetailsRepo.GetuserByUserIdAsync(userid);
            var userCredentialsDetails = await _userCredentialsRepo.GetUserCredentialsByUserIdAsync(userid);
            var userAllocationMenus = await _userMenuEntityRepo.GetAllocatedMenusForUser(userid);   
            var convertedUserDetails = UserMapper.ConvertToUserViewModel(userBasicDetails, userCredentialsDetails, userAllocationMenus);
            return convertedUserDetails;

        }

        public async Task InsertNewUserDetails(UserViewModel newUserDetails)
        {
            Guid _newUserId= Guid.NewGuid();
            newUserDetails.UserId = _newUserId;
            var _newUserEntity= UserMapper.ConvertUserViewModelToUserEntity(newUserDetails);
            var _newUserCredEntity= UserMapper.ConvertUserViewModelToUserCredentialEntity(newUserDetails);
            var _newUserMenuEntity = UserMapper.ConvertUserViewModelToUserMenuEntity(newUserDetails);

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // Insert user entity
                    await _userBasicDetailsRepo.AddUserBasicDetailsAsync(_newUserEntity);

                    // Insert user credential entity
                    await _userCredentialsRepo.AddUserCredentialDetailsAsync(_newUserCredEntity);

                    // Insert user menu entity
                    await _userMenuEntityRepo.AddAllocatedMenusForUserAsync(_newUserMenuEntity);

                    // Commit the transaction if all operations succeed
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if an exception occurs
                    transactionScope.Dispose();
                    throw;
                    // Handle exception or rethrow if needed
                }
            }

            //throw new NotImplementedException();
        }

        public async Task<UserViewModel> ValidateUser(string username, string password)
        {
            var userCredentialsDetails = await _userCredentialsRepo.GetUserCredentialsByUsernameAsync(username);

            if (userCredentialsDetails != null)
            {
                // Verify the provided password
                bool isValidPassword = PasswordHelper.VerifyPassword(password, userCredentialsDetails.HashedPassword);

                if (isValidPassword)
                {
                    // Password is valid, retrieve user details
                    var userBasicDetails = await _userBasicDetailsRepo.GetuserByUserIdAsync(userCredentialsDetails.UserId);
                    var userMenuDetails = await _userMenuEntityRepo.GetAllocatedMenusForUser(userCredentialsDetails.UserId);
                    var convertedUserDetails = UserMapper.ConvertToUserViewModel(userBasicDetails, userCredentialsDetails,userMenuDetails);
                    return convertedUserDetails;
                }
            }

            // If user does not exist or password is invalid, return null or throw an exception
            return null;
        }
    }
}
