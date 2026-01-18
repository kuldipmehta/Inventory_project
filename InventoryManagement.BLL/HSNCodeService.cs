using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class HSNCodeService : IHSNCodeService
    {
        HSNCodeRepository hsnCodeRepository = null;

        public async Task<IEnumerable<int>> AddHSNCode(HSNCode hsnCode)
        {
            using (hsnCodeRepository = new HSNCodeRepository())
            {
                return await hsnCodeRepository.AddHSNCode(hsnCode);
            }
        }

        public async Task<IEnumerable<int>> EditHSNCode(HSNCode hsnCode)
        {
            using (hsnCodeRepository = new HSNCodeRepository())
            {
                return await hsnCodeRepository.EditHSNCode(hsnCode);
            }
        }

        public async Task<IEnumerable<HSNCode>> HSNCodeList()
        {
            using (hsnCodeRepository = new HSNCodeRepository())
            {
                return await hsnCodeRepository.HSNCodeList();
            }
        }

        public async Task<IEnumerable<HSNTax>> GetHSNTaxDetailsByHSNCodeId(int hsnCodeId)
        {
            using (hsnCodeRepository = new HSNCodeRepository())
            {
                return await hsnCodeRepository.GetHSNTaxDetailsByHSNCodeId(hsnCodeId);
            }
        }

        public async Task<IEnumerable<int>> DeleteHSNCode(int hsnCodeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (hsnCodeRepository = new HSNCodeRepository())
            {
                return await hsnCodeRepository.DeleteHSNCode(hsnCodeId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
