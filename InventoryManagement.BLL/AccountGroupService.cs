using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class AccountGroupService : IAccountGroupService
    {
        AccountGroupRepository accountGroupRepository = null;

        public async Task<IEnumerable<int>> AddAccountGroup(AccountGroup group)
        {
            using (accountGroupRepository = new AccountGroupRepository())
            {
                return await accountGroupRepository.AddAccountGroup(group);
            }
        }

        public async Task<IEnumerable<int>> EditAccountGroup(AccountGroup group)
        {
            using (accountGroupRepository = new AccountGroupRepository())
            {
                return await accountGroupRepository.EditAccountGroup(group);
            }
        }

        public async Task<IEnumerable<AccountGroup>> AccountGroupList()
        {
            using (accountGroupRepository = new AccountGroupRepository())
            {
                return await accountGroupRepository.AccountGroupList();
            }
        }

        public async Task<IEnumerable<int>> DeleteAccountGroup(int groupId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (accountGroupRepository = new AccountGroupRepository())
            {
                return await accountGroupRepository.DeleteAccountGroup(groupId, isActive, updatedBy, changeTimeStamp);
            }
        }

        public async Task<IEnumerable<AccountGroupType>> AccountGroupTypeList()
        {
            using (accountGroupRepository = new AccountGroupRepository())
            {
                return await accountGroupRepository.AccountGroupTypeList();
            }
        }
    }

}
