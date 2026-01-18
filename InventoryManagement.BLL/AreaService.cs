using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class AreaService : IAreaService
    {
        AreaRepository areaRepository = null;

        public async Task<IEnumerable<int>> AddArea(Area area)
        {
            using (areaRepository = new AreaRepository())
            {
                return await areaRepository.AddArea(area);
            }
        }

        public async Task<IEnumerable<int>> EditArea(Area area)
        {
            using (areaRepository = new AreaRepository())
            {
                return await areaRepository.EditArea(area);
            }
        }

        public async Task<IEnumerable<Area>> AreaList()
        {
            using (areaRepository = new AreaRepository())
            {
                return await areaRepository.AreaList();
            }
        }

        public async Task<IEnumerable<int>> DeleteArea(int areaId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (areaRepository = new AreaRepository())
            {
                return await areaRepository.DeleteArea(areaId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }
}
