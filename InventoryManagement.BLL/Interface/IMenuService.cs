using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> MenuList();
        Task<IEnumerable<int>> AddMenu(Menu menu);
        Task<IEnumerable<int>> EditMenu(Menu menu);
        Task<IEnumerable<int>> DeleteMenu(int menuId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
