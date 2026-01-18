
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class SizeGroupService : ISizeGroupService
    {
        SizeGroupRepository sizeGroupRepository = null;

        public async Task<IEnumerable<int>> AddSizeGroup(SizeGroup SizeGroup)
        {
            using (sizeGroupRepository = new SizeGroupRepository())
            {
                return await sizeGroupRepository.AddSizeGroup(SizeGroup);
            }
        }

        public async Task<IEnumerable<int>> EditSizeGroup(SizeGroup SizeGroup)
        {
            using (sizeGroupRepository = new SizeGroupRepository())
            {
                return await sizeGroupRepository.EditSizeGroup(SizeGroup);
            }
        }

        public async Task<IEnumerable<SizeGroup>> SizeGroupList()
        {
            using (sizeGroupRepository = new SizeGroupRepository())
            {
                return await sizeGroupRepository.SizeGroupList();
            }
        }

        public async Task<IEnumerable<int>> DeleteSizeGroup(int SizeGroupId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (sizeGroupRepository = new SizeGroupRepository())
            {
                return await sizeGroupRepository.DeleteSizeGroup(SizeGroupId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
