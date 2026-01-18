using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> ColorList();
        Task<IEnumerable<int>> AddColor(Color color);
        Task<IEnumerable<int>> EditColor(Color color);
        Task<IEnumerable<int>> DeleteColor(int colorId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
