using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class TermsNConditionService : ITermsNCondition
    {
        TermsNConditionRepository TermsNConditionRepository = null;

        public async Task<IEnumerable<int>> AddTermsNCondition(TermsNCondition group)
        {
            using (TermsNConditionRepository = new TermsNConditionRepository())
            {
                return await TermsNConditionRepository.AddTermsNCondition(group);
            }
        }

        public async Task<IEnumerable<int>> EditTermsNCondition(TermsNCondition group)
        {
            using (TermsNConditionRepository = new TermsNConditionRepository())
            {
                return await TermsNConditionRepository.EditTermsNCondition(group);
            }
        }

        public async Task<IEnumerable<Branch>> BranchList()
        {
            using (TermsNConditionRepository = new TermsNConditionRepository())
            {
                return await TermsNConditionRepository.BranchList();
            }
        }
    }

}
