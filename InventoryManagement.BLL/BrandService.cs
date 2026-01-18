using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class BrandService : IBrandService
    {
        BrandRepository brandRepository = null;

        public async Task<IEnumerable<int>> AddBrand(Brand Brand)
        {
            using (brandRepository = new BrandRepository())
            {
                return await brandRepository.AddBrand(Brand);
            }
        }

        public async Task<IEnumerable<int>> EditBrand(Brand Brand)
        {
            using (brandRepository = new BrandRepository())
            {
                return await brandRepository.EditBrand(Brand);
            }
        }

        public async Task<IEnumerable<Brand>> BrandList()
        {
            using (brandRepository = new BrandRepository())
            {
                return await brandRepository.BrandList();
            }
        }

        public async Task<IEnumerable<int>> DeleteBrand(int BrandId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (brandRepository = new BrandRepository())
            {
                return await brandRepository.DeleteBrand(BrandId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
