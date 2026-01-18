using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class ColorService : IColorService
    {
        ColorRepository colorRepository = null;

        public async Task<IEnumerable<int>> AddColor(Color Color)
        {
            using (colorRepository = new ColorRepository())
            {
                return await colorRepository.AddColor(Color);
            }
        }

        public async Task<IEnumerable<int>> EditColor(Color Color)
        {
            using (colorRepository = new ColorRepository())
            {
                return await colorRepository.EditColor(Color);
            }
        }

        public async Task<IEnumerable<Color>> ColorList()
        {
            using (colorRepository = new ColorRepository())
            {
                return await colorRepository.ColorList();
            }
        }

        public async Task<IEnumerable<int>> DeleteColor(int ColorId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (colorRepository = new ColorRepository())
            {
                return await colorRepository.DeleteColor(ColorId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
