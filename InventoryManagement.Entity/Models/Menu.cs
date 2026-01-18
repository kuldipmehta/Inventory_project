using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.Entity.Models
{
    public class Menu : BaseModel
    {
        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int ParentId { get; set; }

        public string Permissions { get; set; }

        public int[] PermissionIds { get { return string.IsNullOrEmpty(Permissions)? (new int[0]) : Permissions.Split(',',StringSplitOptions.RemoveEmptyEntries).Select(a => Convert.ToInt32(a)).ToArray(); } }

    }

}
