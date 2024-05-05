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
    public class MenuMapper
    {
        public static List<MenuViewModel> ConvertToMenuViewModel(IEnumerable<MenuEntity> menuentity, IEnumerable<MenuItemsEntity> menuitemsentity)
        {
            // Creating a list to store MenuViewModels
            List<MenuViewModel> menuViewModelList = new List<MenuViewModel>();

            // Loop through MenuEntities (headers)
            foreach (var headerEntity in menuentity)
            {
                // Filter MenuItemsEntities for the current header
                var itemsForHeader = menuitemsentity.Where(item => item.ParentMenuCode == headerEntity.MenuCode);

                // Creating a list to store MenuDetailsModels for the current header
                List<MenuDetailsModel> menuDetailsList = new List<MenuDetailsModel>();

                // Creating MenuViewModel for the current header
                MenuViewModel menuViewModel = new MenuViewModel()
                {
                    MenuHeaderCode = headerEntity.MenuCode,
                    MenuHeaderName = headerEntity.MenuHeader,
                    MenuHeaderOrder = headerEntity.MenuOrder,
                    MenuDetails = menuDetailsList
                };

                // Loop through MenuItemsEntities for the current header
                foreach (var itemEntity in itemsForHeader)
                {
                    MenuDetailsModel menuDetails = new MenuDetailsModel()
                    {
                        MenuHeaderCode = itemEntity.ParentMenuCode,
                        MenuDetailsCode = itemEntity.MenuItemCode,
                        MenuDetailsName = itemEntity.MenuName,
                        MenuDetailsDescription = itemEntity.MenuDescription,
                        MenuDetailsUrl = itemEntity.MenuUrl,
                        MenuDetailsOrder = itemEntity.MenuOrder
                    };

                    menuDetailsList.Add(menuDetails);
                }

                

                // Adding the MenuViewModel to the list
                menuViewModelList.Add(menuViewModel);
            }

            return menuViewModelList;
        }

        public static (List<MenuEntity>, List<MenuItemsEntity>) ConvertToEntities(MenuViewModel menuViewModel)
        {
            // Initialize lists to store MenuEntity and MenuItemsEntity
            List<MenuEntity> menuEntities = new List<MenuEntity>();
            List<MenuItemsEntity> menuItemsEntities = new List<MenuItemsEntity>();

            // Create MenuEntity from MenuViewModel's header information
            MenuEntity menuEntity = new MenuEntity
            {
                MenuCode = menuViewModel.MenuHeaderCode,
                MenuHeader = menuViewModel.MenuHeaderName,
                MenuOrder = menuViewModel.MenuHeaderOrder
            };
            menuEntities.Add(menuEntity);

            // Create MenuItemsEntity for each MenuDetailsModel in MenuViewModel
            foreach (var menuDetails in menuViewModel.MenuDetails)
            {
                MenuItemsEntity menuItemsEntity = new MenuItemsEntity
                {
                    ParentMenuCode = menuDetails.MenuHeaderCode,
                    MenuItemCode = menuDetails.MenuDetailsCode,
                    MenuName = menuDetails.MenuDetailsName,
                    MenuDescription = menuDetails.MenuDetailsDescription,
                    MenuUrl = menuDetails.MenuDetailsUrl,
                    MenuOrder = menuDetails.MenuDetailsOrder
                };
                menuItemsEntities.Add(menuItemsEntity);
            }

            return (menuEntities, menuItemsEntities);
        }
    }
}
