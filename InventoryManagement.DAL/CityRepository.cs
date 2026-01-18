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
    public class CityRepository : BaseRepository
    {
        public async Task<IEnumerable<City>> CityList(bool isActive = true)
        {
            IEnumerable<City> CityList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CityList = await connection.QueryAsync<City>("GetCityDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return CityList;
        }

        public async Task<IEnumerable<int>> AddCity(City city)
        {
            IEnumerable<int> CityList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CityName", city.CityName);
            parameter.Add("@StateId", city.StateId);
            parameter.Add("@CreatedBy", city.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CityList = await connection.QueryAsync<int>("AddCity",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CityList;
        }

        public async Task<IEnumerable<int>> EditCity(City city)
        {
            IEnumerable<int> CityList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CityId", city.CityId);
            parameter.Add("@CityName", city.CityName);
            parameter.Add("@StateId", city.StateId);
            parameter.Add("@UpdatedBy", city.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", city.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CityList = await connection.QueryAsync<int>("EditCity",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CityList;
        }

        public async Task<IEnumerable<int>> DeleteCity(int cityId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> CityList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CityId", cityId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CityList = await connection.QueryAsync<int>("DeleteUnDeleteCity",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CityList;
        }
    }
}
