using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IHSNCodeService
    {
        Task<IEnumerable<HSNCode>> HSNCodeList();
        Task<IEnumerable<HSNTax>> GetHSNTaxDetailsByHSNCodeId(int hsnCodeId);
        Task<IEnumerable<int>> AddHSNCode(HSNCode hsnCode);
        Task<IEnumerable<int>> EditHSNCode(HSNCode hsnCode);
        Task<IEnumerable<int>> DeleteHSNCode(int hsnCodeId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
