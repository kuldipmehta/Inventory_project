using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class RolePermissions : BaseModel
    {
        public int RolePermissionId { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public int PermissionId { get; set; }

        public bool HasPermission { get; set; }
    }

    public class PermissionList
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool? HasPermission { get; set; }

    }

    public class RolePermissionList
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string ParentName { get; set; }
        public List<PermissionList> Permissions { get; set; }
    }

    public class SaveRolePermissionList
    {
        public int roleId { get; set; }
        public List<RolePermissionList> RolePermissionList { get; set; }
    }


    public class RolePermissionType
    {
        public int MenuId { get; set; }
        public int PermissionId { get; set; }
        public bool? HasPermission { get; set; }
    }
}
