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
    public class CustomerCategoryRepository : BaseRepository
    {
        public async Task<IEnumerable<CustomerCategory>> CustomerCategoryList(bool isActive = true)
        {
            IEnumerable<CustomerCategory> CustomerCategoryList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CustomerCategoryList = await connection.QueryAsync<CustomerCategory>("GetCustomerCategoryDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return CustomerCategoryList;
        }

        public async Task<IEnumerable<int>> AddCustomerCategory(CustomerCategory customerCategory)
        {
            IEnumerable<int> CustomerCategoryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CustomerCategoryName", customerCategory.CustomerCategoryName);
            parameter.Add("@CreatedBy", customerCategory.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CustomerCategoryList = await connection.QueryAsync<int>("AddCustomerCategory",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CustomerCategoryList;
        }

        public async Task<IEnumerable<int>> EditCustomerCategory(CustomerCategory customerCategory)
        {
            IEnumerable<int> CustomerCategoryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CustomerCategoryId", customerCategory.CustomerCategoryId);
            parameter.Add("@CustomerCategoryName", customerCategory.CustomerCategoryName);
            parameter.Add("@UpdatedBy", customerCategory.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", customerCategory.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CustomerCategoryList = await connection.QueryAsync<int>("EditCustomerCategory",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CustomerCategoryList;
        }

        public async Task<IEnumerable<int>> DeleteCustomerCategory(int customerCategoryId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> CustomerCategoryList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@CustomerCategoryId", customerCategoryId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                CustomerCategoryList = await connection.QueryAsync<int>("DeleteUnDeleteCustomerCategory",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return CustomerCategoryList;
        }
    }
}
