using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> CountryList();
        Task<IEnumerable<int>> AddCountry(Country country);
        Task<IEnumerable<int>> EditCountry(Country country);
        Task<IEnumerable<int>> DeleteCountry(int countryId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
