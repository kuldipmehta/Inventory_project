using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IStyleService
    {
        Task<IEnumerable<Style>> StyleList();
        Task<IEnumerable<int>> AddStyle(Style style);
        Task<IEnumerable<int>> EditStyle(Style style);
        Task<IEnumerable<int>> DeleteStyle(int styleId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
