using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ICityService
    {
        Task<IEnumerable<City>> CityList();
        Task<IEnumerable<int>> AddCity(City city);
        Task<IEnumerable<int>> EditCity(City city);
        Task<IEnumerable<int>> DeleteCity(int cityId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
