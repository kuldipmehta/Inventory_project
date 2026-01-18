using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ITermsNCondition
    {
       
        Task<IEnumerable<Branch>> BranchList();
        Task<IEnumerable<int>> AddTermsNCondition(TermsNCondition group);
        Task<IEnumerable<int>> EditTermsNCondition(TermsNCondition group);
        
    }
}
