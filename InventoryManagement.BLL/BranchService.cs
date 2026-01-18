using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class BranchService : IBranchService
    {
        BranchRepository branchRepository = null;

        public async Task<IEnumerable<int>> AddBranch(Branch Branch)
        {
            using (branchRepository = new BranchRepository())
            {
                return await branchRepository.AddBranch(Branch);
            }
        }

        public async Task<IEnumerable<int>> EditBranch(Branch Branch)
        {
            using (branchRepository = new BranchRepository())
            {
                return await branchRepository.EditBranch(Branch);
            }
        }

        public async Task<IEnumerable<Branch>> BranchList()
        {
            using (branchRepository = new BranchRepository())
            {
                return await branchRepository.BranchList();
            }
        }

        public async Task<IEnumerable<int>> DeleteBranch(int BranchId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (branchRepository = new BranchRepository())
            {
                return await branchRepository.DeleteBranch(BranchId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
