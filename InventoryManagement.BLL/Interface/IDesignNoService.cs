
using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IDesignNoService
    {
        Task<IEnumerable<DesignNos>> DesignNoList();
        Task<IEnumerable<int>> AddDesignNo(DesignNos designNo);
        Task<IEnumerable<int>> EditDesignNo(DesignNos designNo);
        Task<IEnumerable<int>> DeleteDesignNo(int designNoId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
