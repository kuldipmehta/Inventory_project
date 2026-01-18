using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class GlobalSettingService : IGlobalSettingService
    {
        GlobalSettingRepository globalSettingRepository = null;

        public async Task<IEnumerable<int>> UpdateGlobalSetting(GlobalSetting globalSetting)
        {
            using (globalSettingRepository = new GlobalSettingRepository())
            {
                return await globalSettingRepository.UpdateGlobalSetting(globalSetting);
            }
        }

        public async Task<GlobalSetting> GlobalSetting()
        {
            using (globalSettingRepository = new GlobalSettingRepository())
            {
                return await globalSettingRepository.GlobalSetting();
            }
        }
    }

}
