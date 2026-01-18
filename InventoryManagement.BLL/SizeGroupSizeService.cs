
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class SizeGroupSizeService : ISizeGroupSizeService
    {
        SizeGroupSizeRepository sizeGroupSizeRepository = null;

        public async Task<IEnumerable<int>> AddSizeGroupSize(SizeGroupSize SizeGroupSize)
        {
            using (sizeGroupSizeRepository = new SizeGroupSizeRepository())
            {
                return await sizeGroupSizeRepository.AddSizeGroupSize(SizeGroupSize);
            }
        }

        public async Task<IEnumerable<int>> EditSizeGroupSize(SizeGroupSize SizeGroupSize)
        {
            using (sizeGroupSizeRepository = new SizeGroupSizeRepository())
            {
                return await sizeGroupSizeRepository.EditSizeGroupSize(SizeGroupSize);
            }
        }

        public async Task<IEnumerable<SizeGroupSize>> SizeGroupSizeList()
        {
            using (sizeGroupSizeRepository = new SizeGroupSizeRepository())
            {
                return await sizeGroupSizeRepository.SizeGroupSizeList();
            }
        }

        public async Task<IEnumerable<int>> DeleteSizeGroupSize(int SizeGroupSizeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (sizeGroupSizeRepository = new SizeGroupSizeRepository())
            {
                return await sizeGroupSizeRepository.DeleteSizeGroupSize(SizeGroupSizeId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
