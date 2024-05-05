using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.Mappers;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Entities.Models;
using SLM.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Services
{
    public class MenuService : IMenuService
    {

        private readonly IMenuEntityRepository _menuRepo;
        private readonly IMenuItemsEntityRepository _menuItemsRepo;
        public MenuService(
            IMenuEntityRepository menuEntityRepository,
            IMenuItemsEntityRepository menuItemsEntityRepository)
        {
            _menuRepo = menuEntityRepository;
            _menuItemsRepo = menuItemsEntityRepository;
        }

        public Task<IEnumerable<MenuViewModel>> GetAllMenuAssignedforUser(Guid userid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MenuViewModel>> GetAllMenuAsync()
        {
            var menuHeaders = await _menuRepo.GetAllMenuHeaders();
            var menuItems = await _menuItemsRepo.GetAllMenuItems();
            // Convert fetched entities to MenuViewModel
            var menuViewModels = MenuMapper.ConvertToMenuViewModel(menuHeaders, menuItems);
            return menuViewModels.AsEnumerable();           
        }
    }
}
