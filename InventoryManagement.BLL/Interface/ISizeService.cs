
using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ISizeService
    {
        Task<IEnumerable<Size>> SizeList();
        Task<IEnumerable<int>> AddSize(Size size);
        Task<IEnumerable<int>> EditSize(Size size);
        Task<IEnumerable<int>> DeleteSize(int sizeId, bool isActive, int updatedBy, byte[] changeTimeStamp);
        Task<IEnumerable<SizeCountry>> GetSizeCountyDetailsById(int sizeId);
    }
}
