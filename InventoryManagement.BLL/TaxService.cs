using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class TaxService : ITaxService
    {
        TaxRepository taxRepository = null;

        public async Task<IEnumerable<int>> AddTax(Tax tax)
        {
            using (taxRepository = new TaxRepository())
            {
                return await taxRepository.AddTax(tax);
            }
        }

        public async Task<IEnumerable<int>> EditTax(Tax tax)
        {
            using (taxRepository = new TaxRepository())
            {
                return await taxRepository.EditTax(tax);
            }
        }

        public async Task<IEnumerable<Tax>> TaxList()
        {
            using (taxRepository = new TaxRepository())
            {
                return await taxRepository.TaxList();
            }
        }

        public async Task<IEnumerable<TaxType>> TaxTypeList()
        {
            using (taxRepository = new TaxRepository())
            {
                return await taxRepository.TaxTypeList();
            }
        }

        public async Task<IEnumerable<int>> DeleteTax(int taxId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (taxRepository = new TaxRepository())
            {
                return await taxRepository.DeleteTax(taxId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
