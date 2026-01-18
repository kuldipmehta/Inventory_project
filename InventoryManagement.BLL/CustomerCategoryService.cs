
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class CustomerCategoryService : ICustomerCategoryService
    {
        CustomerCategoryRepository customerCategoryRepository = null;

        public async Task<IEnumerable<int>> AddCustomerCategory(CustomerCategory CustomerCategory)
        {
            using (customerCategoryRepository = new CustomerCategoryRepository())
            {
                return await customerCategoryRepository.AddCustomerCategory(CustomerCategory);
            }
        }

        public async Task<IEnumerable<int>> EditCustomerCategory(CustomerCategory CustomerCategory)
        {
            using (customerCategoryRepository = new CustomerCategoryRepository())
            {
                return await customerCategoryRepository.EditCustomerCategory(CustomerCategory);
            }
        }

        public async Task<IEnumerable<CustomerCategory>> CustomerCategoryList()
        {
            using (customerCategoryRepository = new CustomerCategoryRepository())
            {
                return await customerCategoryRepository.CustomerCategoryList();
            }
        }

        public async Task<IEnumerable<int>> DeleteCustomerCategory(int CustomerCategoryId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (customerCategoryRepository = new CustomerCategoryRepository())
            {
                return await customerCategoryRepository.DeleteCustomerCategory(CustomerCategoryId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
