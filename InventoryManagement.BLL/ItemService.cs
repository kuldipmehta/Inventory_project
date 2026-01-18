
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class ItemService : IItemService
    {
        ItemRepository itemRepository = null;

        public async Task<IEnumerable<int>> AddItem(Item Item)
        {
            using (itemRepository = new ItemRepository())
            {
                return await itemRepository.AddItem(Item);
            }
        }

        public async Task<IEnumerable<int>> EditItem(Item Item)
        {
            using (itemRepository = new ItemRepository())
            {
                return await itemRepository.EditItem(Item);
            }
        }

        public async Task<IEnumerable<Item>> ItemList()
        {
            using (itemRepository = new ItemRepository())
            {
                return await itemRepository.ItemList();
            }
        }

        public async Task<IEnumerable<int>> DeleteItem(int ItemId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (itemRepository = new ItemRepository())
            {
                return await itemRepository.DeleteItem(ItemId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
