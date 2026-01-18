using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IItemGroupService
    {
        Task<IEnumerable<ItemGroup>> ItemGroupList();
        Task<IEnumerable<int>> AddItemGroup(ItemGroup itemGroup);
        Task<IEnumerable<int>> EditItemGroup(ItemGroup itemGroup);
        Task<IEnumerable<int>> DeleteItemGroup(int itemGroupId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
