using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class SizeService : ISizeService
    {
        SizeRepository sizeRepository = null;

        public async Task<IEnumerable<int>> AddSize(Size size)
        {
            using (sizeRepository = new SizeRepository())
            {
                return await sizeRepository.AddSize(size);
            }
        }

        public async Task<IEnumerable<int>> EditSize(Size size)
        {
            using (sizeRepository = new SizeRepository())
            {
                return await sizeRepository.EditSize(size);
            }
        }

        public async Task<IEnumerable<Size>> SizeList()
        {
            using (sizeRepository = new SizeRepository())
            {
                return await sizeRepository.SizeList();
            }
        }

        public async Task<IEnumerable<int>> DeleteSize(int sizeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (sizeRepository = new SizeRepository())
            {
                return await sizeRepository.DeleteSize(sizeId, isActive, updatedBy, changeTimeStamp);
            }
        }

        public async Task<IEnumerable<SizeCountry>> GetSizeCountyDetailsById(int sizeId)
        {
            using (sizeRepository = new SizeRepository())
            {
                return await sizeRepository.GetSizeCountyDetailsById(sizeId);
            }
        }
    }

}
