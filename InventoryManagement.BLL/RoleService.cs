using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class RoleService : IRoleService
    {
        RoleRepository roleRepository = null;

        public async Task<IEnumerable<int>> AddRole(ApplicationRole role)
        {
            using (roleRepository = new RoleRepository())
            {
                return await roleRepository.AddRole(role);
            }
        }

        public async Task<IEnumerable<int>> EditRole(ApplicationRole role)
        {
            using (roleRepository = new RoleRepository())
            {
                return await roleRepository.EditRole(role);
            }
        }

        public async Task<IEnumerable<ApplicationRole>> RoleList()
        {
            using (roleRepository = new RoleRepository())
            {
                return await roleRepository.RoleList();
            }
        }

        public async Task<IEnumerable<RolePermissions>> RolePermissionList(int roleId)
        {
            using (roleRepository = new RoleRepository())
            {
                return await roleRepository.RolePermissionList(roleId);
            }
        }


        public async Task<IEnumerable<int>> SaveRolePermission(List<RolePermissionType> rolePermissionTypes, int roleId)
        {
            using (roleRepository = new RoleRepository())
            {
                return await roleRepository.SaveRolePermissionList(rolePermissionTypes, roleId);
            }
        }

        public async Task<IEnumerable<int>> DeleteRole(int roleId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (roleRepository = new RoleRepository())
            {
                return await roleRepository.DeleteRole(roleId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }
}
