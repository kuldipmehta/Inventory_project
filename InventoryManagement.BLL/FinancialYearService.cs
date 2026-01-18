using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class FinancialYearService : IFinancialYearService
    {
        FinancialYearRepository financialYearRepository = null;

        public async Task<IEnumerable<int>> AddFinancialYear(FinancialYear FinancialYear)
        {
            using (financialYearRepository = new FinancialYearRepository())
            {
                return await financialYearRepository.AddFinancialYear(FinancialYear);
            }
        }

        public async Task<IEnumerable<int>> EditFinancialYear(FinancialYear FinancialYear)
        {
            using (financialYearRepository = new FinancialYearRepository())
            {
                return await financialYearRepository.EditFinancialYear(FinancialYear);
            }
        }

        public async Task<IEnumerable<FinancialYear>> FinancialYearList()
        {
            using (financialYearRepository = new FinancialYearRepository())
            {
                return await financialYearRepository.FinancialYearList();
            }
        }

        public async Task<IEnumerable<int>> DeleteFinancialYear(int FinancialYearId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (financialYearRepository = new FinancialYearRepository())
            {
                return await financialYearRepository.DeleteFinancialYear(FinancialYearId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
