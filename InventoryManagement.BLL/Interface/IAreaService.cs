using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> AreaList();
        Task<IEnumerable<int>> AddArea(Area area);
        Task<IEnumerable<int>> EditArea(Area area);
        Task<IEnumerable<int>> DeleteArea(int areaId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
