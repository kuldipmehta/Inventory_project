using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class ItemGroupService : IItemGroupService
    {
        ItemGroupRepository itemGroupRepository = null;

        public async Task<IEnumerable<int>> AddItemGroup(ItemGroup ItemGroup)
        {
            using (itemGroupRepository = new ItemGroupRepository())
            {
                return await itemGroupRepository.AddItemGroup(ItemGroup);
            }
        }

        public async Task<IEnumerable<int>> EditItemGroup(ItemGroup ItemGroup)
        {
            using (itemGroupRepository = new ItemGroupRepository())
            {
                return await itemGroupRepository.EditItemGroup(ItemGroup);
            }
        }

        public async Task<IEnumerable<ItemGroup>> ItemGroupList()
        {
            using (itemGroupRepository = new ItemGroupRepository())
            {
                return await itemGroupRepository.ItemGroupList();
            }
        }

        public async Task<IEnumerable<int>> DeleteItemGroup(int ItemGroupId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (itemGroupRepository = new ItemGroupRepository())
            {
                return await itemGroupRepository.DeleteItemGroup(ItemGroupId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
