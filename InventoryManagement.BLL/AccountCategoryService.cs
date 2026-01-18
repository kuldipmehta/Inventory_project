
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class AccountCategoryService : IAccountCategoryService
    {
        AccountCategoryRepository accountCategoryRepository = null;

        public async Task<IEnumerable<int>> AddAccountCategory(AccountCategory AccountCategory)
        {
            using (accountCategoryRepository = new AccountCategoryRepository())
            {
                return await accountCategoryRepository.AddAccountCategory(AccountCategory);
            }
        }

        public async Task<IEnumerable<int>> EditAccountCategory(AccountCategory AccountCategory)
        {
            using (accountCategoryRepository = new AccountCategoryRepository())
            {
                return await accountCategoryRepository.EditAccountCategory(AccountCategory);
            }
        }

        public async Task<IEnumerable<AccountCategory>> AccountCategoryList()
        {
            using (accountCategoryRepository = new AccountCategoryRepository())
            {
                return await accountCategoryRepository.AccountCategoryList();
            }
        }

        public async Task<IEnumerable<int>> DeleteAccountCategory(int AccountCategoryId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (accountCategoryRepository = new AccountCategoryRepository())
            {
                return await accountCategoryRepository.DeleteAccountCategory(AccountCategoryId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
