using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ISizeGroupSizeService
    {
        Task<IEnumerable<SizeGroupSize>> SizeGroupSizeList();
        Task<IEnumerable<int>> AddSizeGroupSize(SizeGroupSize sizeGroupSize);
        Task<IEnumerable<int>> EditSizeGroupSize(SizeGroupSize sizeGroupSize);
        Task<IEnumerable<int>> DeleteSizeGroupSize(int sizeGroupSizeId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
