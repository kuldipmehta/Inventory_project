using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class CityService : ICityService
    {
        CityRepository cityRepository = null;

        public async Task<IEnumerable<int>> AddCity(City City)
        {
            using (cityRepository = new CityRepository())
            {
                return await cityRepository.AddCity(City);
            }
        }

        public async Task<IEnumerable<int>> EditCity(City City)
        {
            using (cityRepository = new CityRepository())
            {
                return await cityRepository.EditCity(City);
            }
        }

        public async Task<IEnumerable<City>> CityList()
        {
            using (cityRepository = new CityRepository())
            {
                return await cityRepository.CityList();
            }
        }

        public async Task<IEnumerable<int>> DeleteCity(int CityId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (cityRepository = new CityRepository())
            {
                return await cityRepository.DeleteCity(CityId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }

}
