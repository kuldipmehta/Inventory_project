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
    public class BrandRepository : BaseRepository
    {
        public async Task<IEnumerable<Brand>> BrandList(bool IsActive = true)
        {
            IEnumerable<Brand> BrandList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BrandList = await connection.QueryAsync<Brand>("GetBrandDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return BrandList;
        }

        public async Task<IEnumerable<int>> AddBrand(Brand branch)
        {
            IEnumerable<int> BrandList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@BrandName", branch.BrandName);
            parameter.Add("@ShortName", branch.ShortName);
            parameter.Add("@SrNo", branch.SrNo);
            parameter.Add("@CreatedBy", branch.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BrandList = await connection.QueryAsync<int>("AddBrand",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return BrandList;
        }

        public async Task<IEnumerable<int>> EditBrand(Brand branch)
        {
            IEnumerable<int> BrandList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@BrandId", branch.BrandId);
            parameter.Add("@BrandName", branch.BrandName);
            parameter.Add("@ShortName", branch.ShortName);
            parameter.Add("@SrNo", branch.SrNo);
            parameter.Add("@UpdatedBy", branch.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", branch.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BrandList = await connection.QueryAsync<int>("EditBrand",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return BrandList;
        }

        public async Task<IEnumerable<int>> DeleteBrand(int BrandId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> BrandList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@BrandId", BrandId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                BrandList = await connection.QueryAsync<int>("DeleteUnDeleteBrand",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return BrandList;
        }
    }
}
