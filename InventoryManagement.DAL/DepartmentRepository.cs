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
    public class DepartmentRepository : BaseRepository
    {
        public async Task<IEnumerable<Department>> DepartmentList(bool IsActive = true)
        {
            IEnumerable<Department> DepartmentList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DepartmentList = await connection.QueryAsync<Department>("GetDepartmentDetails",
                                                              new { IsActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return DepartmentList;
        }

        public async Task<IEnumerable<int>> AddDepartment(Department department)
        {
            IEnumerable<int> DepartmentList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@DepartmentName", department.DepartmentName);
            parameter.Add("@CreatedBy", department.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DepartmentList = await connection.QueryAsync<int>("AddDepartment",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return DepartmentList;
        }

        public async Task<IEnumerable<int>> EditDepartment(Department department)
        {
            IEnumerable<int> DepartmentList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@DepartmentId", department.DepartmentId);
            parameter.Add("@DepartmentName", department.DepartmentName);
            parameter.Add("@UpdatedBy", department.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", department.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DepartmentList = await connection.QueryAsync<int>("EditDepartment",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return DepartmentList;
        }

        public async Task<IEnumerable<int>> DeleteDepartment(int DepartmentId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> DepartmentList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@DepartmentId", DepartmentId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                DepartmentList = await connection.QueryAsync<int>("DeleteUnDeleteDepartment",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return DepartmentList;
        }
    }
}
