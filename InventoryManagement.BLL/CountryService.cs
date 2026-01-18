using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class CountryService : ICountryService
    {
        CountryRepository countryRepository = null;

        public async Task<IEnumerable<int>> AddCountry(Country country)
        {
            using (countryRepository = new CountryRepository())
            {
                return await countryRepository.AddCountry(country);
            }
        }

        public async Task<IEnumerable<int>> EditCountry(Country country)
        {
            using (countryRepository = new CountryRepository())
            {
                return await countryRepository.EditCountry(country);
            }
        }

        public async Task<IEnumerable<Country>> CountryList()
        {
            using (countryRepository = new CountryRepository())
            {
                return await countryRepository.CountryList();
            }
        }

        public async Task<IEnumerable<int>> DeleteCountry(int countryId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (countryRepository = new CountryRepository())
            {
                return await countryRepository.DeleteCountry(countryId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }
}
