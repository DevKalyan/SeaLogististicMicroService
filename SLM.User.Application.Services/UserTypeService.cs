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
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeEntityRepository _repo;

        public UserTypeService(
            IUserTypeEntityRepository userTypeEntityRepository)
        {
            _repo = userTypeEntityRepository;
        }

        public async Task DeleteExistingUserType(Guid usertypeId)
        {
            var _userTypeDetails = await _repo.GetUserTypeForUserTypeIdAsync(usertypeId);
            if (_userTypeDetails != null)
            {
                await _repo.DeleteUserTypeAsync(usertypeId);
            }
        }

        public async Task<List<UserTypeViewModel>> GetAllUserTypes()
        {
            var _userTypeList = await _repo.GetAllUserTypesAsync();
            return UserTypeMapper.ConvertUserTypeEntityToUserTypeViewModel(_userTypeList);
        }

        public Task InsertNewUserType(UserTypeViewModel userType)
        {
            var _userTypeEntity = UserTypeMapper.ConvertUserTypeViewModelToUserTypeEntity(userType);
            return _repo.AddNewUserTypeAsync(_userTypeEntity);
        }

        public async Task UpdateExistingUserType(UserTypeViewModel userType)
        {
            var _userTypeDetails = await _repo.GetUserTypeForUserTypeIdAsync(userType.PrimaryId);

            if (_userTypeDetails != null)
            {
                await _repo.UpdateExistingUsertypeAsync(_userTypeDetails);
            }
        }
    }
}
