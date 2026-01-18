
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class DesignNoService : IDesignNoService
    {
        DesignNoRepository designNoRepository = null;

        public async Task<IEnumerable<int>> AddDesignNo(DesignNos DesignNo)
        {
            using (designNoRepository = new DesignNoRepository())
            {
                return await designNoRepository.AddDesignNo(DesignNo);
            }
        }

        public async Task<IEnumerable<int>> EditDesignNo(DesignNos DesignNo)
        {
            using (designNoRepository = new DesignNoRepository())
            {
                return await designNoRepository.EditDesignNo(DesignNo);
            }
        }

        public async Task<IEnumerable<DesignNos>> DesignNoList()
        {
            using (designNoRepository = new DesignNoRepository())
            {
                return await designNoRepository.DesignNoList();
            }
        }

        public async Task<IEnumerable<int>> DeleteDesignNo(int DesignNoId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (designNoRepository = new DesignNoRepository())
            {
                return await designNoRepository.DeleteDesignNo(DesignNoId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
