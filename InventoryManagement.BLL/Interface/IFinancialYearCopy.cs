using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IFinancialYearService
    {
        Task<IEnumerable<FinancialYear>> FinancialYearList();
        Task<IEnumerable<int>> AddFinancialYear(FinancialYear financialYear);
        Task<IEnumerable<int>> EditFinancialYear(FinancialYear financialYear);
        Task<IEnumerable<int>> DeleteFinancialYear(int FinancialYearId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
