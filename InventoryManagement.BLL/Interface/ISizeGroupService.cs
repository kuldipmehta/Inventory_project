
using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ISizeGroupService
    {
        Task<IEnumerable<SizeGroup>> SizeGroupList();
        Task<IEnumerable<int>> AddSizeGroup(SizeGroup sizeGroup);
        Task<IEnumerable<int>> EditSizeGroup(SizeGroup sizeGroup);
        Task<IEnumerable<int>> DeleteSizeGroup(int sizeGroupId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
