using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> BranchList();
        Task<IEnumerable<int>> AddBranch(Branch branch);
        Task<IEnumerable<int>> EditBranch(Branch branch);
        Task<IEnumerable<int>> DeleteBranch(int branchId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
