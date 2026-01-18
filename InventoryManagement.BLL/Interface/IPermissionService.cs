using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> PermissionList();
        Task<IEnumerable<int>> AddPermission(Permission permission);
        Task<IEnumerable<int>> EditPermission(Permission permission);
        Task<IEnumerable<int>> DeletePermission(int permissionId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
