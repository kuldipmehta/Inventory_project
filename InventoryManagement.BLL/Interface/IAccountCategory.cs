using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IAccountCategoryService
    {
        Task<IEnumerable<AccountCategory>> AccountCategoryList();
        Task<IEnumerable<int>> AddAccountCategory(AccountCategory AccountCategory);
        Task<IEnumerable<int>> EditAccountCategory(AccountCategory AccountCategory);
        Task<IEnumerable<int>> DeleteAccountCategory(int AccountCategoryId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
