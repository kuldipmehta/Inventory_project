using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> ItemList();
        Task<IEnumerable<int>> AddItem(Item item);
        Task<IEnumerable<int>> EditItem(Item item);
        Task<IEnumerable<int>> DeleteItem(int itemId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
