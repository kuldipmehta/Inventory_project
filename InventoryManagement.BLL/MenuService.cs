using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class MenuService : IMenuService
    {
        MenuRepository menuRepository = null;

        public async Task<IEnumerable<int>> AddMenu(Menu menu)
        {
            using (menuRepository = new MenuRepository())
            {
                return await menuRepository.AddMenu(menu);
            }
        }

        public async Task<IEnumerable<int>> EditMenu(Menu menu)
        {
            using (menuRepository = new MenuRepository())
            {
                return await menuRepository.EditMenu(menu);
            }
        }

        public async Task<IEnumerable<Menu>> MenuList()
        {
            using (menuRepository = new MenuRepository())
            {
                return await menuRepository.MenuList();
            }
        }

        public async Task<IEnumerable<int>> DeleteMenu(int menuId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (menuRepository = new MenuRepository())
            {
                return await menuRepository.DeleteMenu(menuId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }
}
