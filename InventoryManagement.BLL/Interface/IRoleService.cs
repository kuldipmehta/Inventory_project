using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IRoleService
    {
        Task<IEnumerable<ApplicationRole>> RoleList();
        Task<IEnumerable<RolePermissions>> RolePermissionList(int roleId);
        Task<IEnumerable<int>> SaveRolePermission(List<RolePermissionType> saveRolePermissionList, int roleId);
        Task<IEnumerable<int>> AddRole(ApplicationRole role);
        Task<IEnumerable<int>> EditRole(ApplicationRole role);
        Task<IEnumerable<int>> DeleteRole(int roleId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
