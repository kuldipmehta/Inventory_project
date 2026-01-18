using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class StyleService : IStyleService
    {
        StyleRepository styleRepository = null;

        public async Task<IEnumerable<int>> AddStyle(Style Style)
        {
            using (styleRepository = new StyleRepository())
            {
                return await styleRepository.AddStyle(Style);
            }
        }

        public async Task<IEnumerable<int>> EditStyle(Style Style)
        {
            using (styleRepository = new StyleRepository())
            {
                return await styleRepository.EditStyle(Style);
            }
        }

        public async Task<IEnumerable<Style>> StyleList()
        {
            using (styleRepository = new StyleRepository())
            {
                return await styleRepository.StyleList();
            }
        }

        public async Task<IEnumerable<int>> DeleteStyle(int StyleId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (styleRepository = new StyleRepository())
            {
                return await styleRepository.DeleteStyle(StyleId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
