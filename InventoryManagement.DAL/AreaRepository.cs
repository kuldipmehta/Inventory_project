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
    public class AreaRepository : BaseRepository
    {
        public async Task<IEnumerable<Area>> AreaList(bool IsActive = true)
        {
            IEnumerable<Area> areaList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                areaList = await connection.QueryAsync<Area>("GetAreaDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return areaList;
        }

        public async Task<IEnumerable<int>> AddArea(Area area)
        {
            IEnumerable<int> areaList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@AreaName", area.AreaName);
            parameter.Add("@PinCode", area.PinCode);
            parameter.Add("@CityId", area.CityId);
            parameter.Add("@RegionCode", area.RegionCode);
            parameter.Add("@CreatedBy", area.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                areaList = await connection.QueryAsync<int>("AddArea",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);

            }
            return areaList;
        }

        public async Task<IEnumerable<int>> EditArea(Area area)
        {
            IEnumerable<int> areaList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@AreaId", area.AreaId);
            parameter.Add("@AreaName", area.AreaName);
            parameter.Add("@PinCode", area.PinCode);
            parameter.Add("@CityId", area.CityId);
            parameter.Add("@RegionCode", area.RegionCode);
            parameter.Add("@UpdatedBy", area.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", area.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output,size:100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                areaList = await connection.QueryAsync<int>("EditArea",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return areaList;
        }

        public async Task<IEnumerable<int>> DeleteArea(int areaId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> areaList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@AreaId", areaId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                areaList = await connection.QueryAsync<int>("DeleteUnDeleteArea",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return areaList;
        }
    }
}
