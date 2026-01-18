using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class PermissionService : IPermissionService
    {
        PermissionRepository permissionRepository = null;

        public async Task<IEnumerable<int>> AddPermission(Permission permission)
        {
            using (permissionRepository = new PermissionRepository())
            {
                return await permissionRepository.AddPermission(permission);
            }
        }

        public async Task<IEnumerable<int>> EditPermission(Permission permission)
        {
            using (permissionRepository = new PermissionRepository())
            {
                return await permissionRepository.EditPermission(permission);
            }
        }

        public async Task<IEnumerable<Permission>> PermissionList()
        {
            using (permissionRepository = new PermissionRepository())
            {
                return await permissionRepository.PermissionList();
            }
        }

        public async Task<IEnumerable<int>> DeletePermission(int permissionId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (permissionRepository = new PermissionRepository())
            {
                return await permissionRepository.DeletePermission(permissionId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }
}
