using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ICustomerCategoryService
    {
        Task<IEnumerable<CustomerCategory>> CustomerCategoryList();
        Task<IEnumerable<int>> AddCustomerCategory(CustomerCategory CustomerCategory);
        Task<IEnumerable<int>> EditCustomerCategory(CustomerCategory CustomerCategory);
        Task<IEnumerable<int>> DeleteCustomerCategory(int CustomerCategoryId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
