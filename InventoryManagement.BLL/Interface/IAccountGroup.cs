using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IAccountGroupService
    {
        Task<IEnumerable<AccountGroup>> AccountGroupList();
        Task<IEnumerable<AccountGroupType>> AccountGroupTypeList();
        Task<IEnumerable<int>> AddAccountGroup(AccountGroup  group);
        Task<IEnumerable<int>> EditAccountGroup(AccountGroup group);
        Task<IEnumerable<int>> DeleteAccountGroup(int groupId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
