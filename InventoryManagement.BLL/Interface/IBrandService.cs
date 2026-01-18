using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> BrandList();
        Task<IEnumerable<int>> AddBrand(Brand brand);
        Task<IEnumerable<int>> EditBrand(Brand brand);
        Task<IEnumerable<int>> DeleteBrand(int brandId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
