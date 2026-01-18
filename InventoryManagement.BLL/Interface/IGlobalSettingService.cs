using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IGlobalSettingService
    {
        Task<GlobalSetting> GlobalSetting();
        Task<IEnumerable<int>> UpdateGlobalSetting(GlobalSetting globalSetting);
    }
}
