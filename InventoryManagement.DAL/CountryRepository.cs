using Dapper;
using InventoryManagement.Common;
using InventoryManagement.Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InventoryManagement.DAL;
using System.Data;

namespace InventoryManagement.DAL
{
    public class CountryRepository : BaseRepository
    {
        public async Task<IEnumerable<Country>> CountryList(bool isActive = true)
        {
            IEnumerable<Country> countryList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                countryList = await connection.QueryAsync<Country>("GetCountryDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return countryList;
        }

        public async Task<IEnumerable<int>> AddCountry(Country country)
        {
            IEnumerable<int> countryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CountryName", country.CountryName);
            parameter.Add("@CountryCode", country.CountryCode);
            parameter.Add("@MobileFixCode", country.MobileFixCode);
            parameter.Add("@CurrencyRate", country.CurrencyRate);
            parameter.Add("@CreatedBy", country.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                countryList = await connection.QueryAsync<int>("AddCountry",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return countryList;
        }

        public async Task<IEnumerable<int>> EditCountry(Country country)
        {
            IEnumerable<int> countryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CountryId", country.CountryId);
            parameter.Add("@CountryName", country.CountryName);
            parameter.Add("@CountryCode", country.CountryCode);
            parameter.Add("@MobileFixCode", country.MobileFixCode);
            parameter.Add("@CurrencyRate", country.CurrencyRate);
            parameter.Add("@UpdatedBy", country.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", country.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output,size:100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                countryList = await connection.QueryAsync<int>("EditCountry",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return countryList;
        }

        public async Task<IEnumerable<int>> DeleteCountry(int countryId, bool isActive, int updatedBy,byte[] changeTimeStamp)
        {
            IEnumerable<int> countryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CountryId", countryId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                countryList = await connection.QueryAsync<int>("DeleteUnDeleteCountry",
                                                               parameter,
                                                               commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return countryList;
        }
    }
}
