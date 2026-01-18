using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.BLL.Interface
{
    public interface IRoleManagement 
    {
        IList<string> GetRole(int rolePriority);
    }
}
