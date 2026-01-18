using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ITaxService
    {
        Task<IEnumerable<Tax>> TaxList();
        Task<IEnumerable<TaxType>> TaxTypeList();
        Task<IEnumerable<int>> AddTax(Tax tax);
        Task<IEnumerable<int>> EditTax(Tax tax);
        Task<IEnumerable<int>> DeleteTax(int taxId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
