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
    public class EmployeeRepository : BaseRepository
    {
        public async Task<IEnumerable<Employee>> EmployeeList(bool isActive = true)
        {
            IEnumerable<Employee> EmployeeList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                EmployeeList = await connection.QueryAsync<Employee>("GetEmployeeDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return EmployeeList;
        }

        public async Task<IEnumerable<EmployeeDepartment>> GetEmployeeDepartmentDetails(bool isActive = true)
        {
            IEnumerable<EmployeeDepartment> EmployeeDepartmentList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                EmployeeDepartmentList = await connection.QueryAsync<EmployeeDepartment>("GetEmployeeDepartmentDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return EmployeeDepartmentList;
        }

        public async Task<IEnumerable<EmployeeDesignation>> GetEmployeeDesignationDetails(bool isActive = true)
        {
            IEnumerable<EmployeeDesignation> EmployeeDesignationList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                EmployeeDesignationList = await connection.QueryAsync<EmployeeDesignation>("GetEmployeeDesignationDetails",
                                                              new { isActive },
                                                              commandType: CommandType.StoredProcedure);
            }
            return EmployeeDesignationList;
        }


        public async Task<IEnumerable<int>> AddEmployee(Employee employee)
        {
            IEnumerable<int> EmployeeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@CompanyId", employee.CompanyId);
            parameter.Add("@BranchId", employee.BranchId);
            parameter.Add("@FirstName", employee.FirstName);
            parameter.Add("@MiddleName", employee.MiddleName);
            parameter.Add("@LastName", employee.LastName);
            parameter.Add("@ShortName", employee.ShortName);
            parameter.Add("@EmployeeCode", employee.EmployeeCode);
            parameter.Add("@DepartmentId", employee.DepartmentId);
            parameter.Add("@DesignationId", employee.DesignationId);
            parameter.Add("@AlloweCompanyId", employee.AlloweCompanyId);
            parameter.Add("@AllowedBranchId", employee.AllowedBranchId);
            parameter.Add("@Address1", employee.Address1);
            parameter.Add("@Address2", employee.Address2);
            parameter.Add("@Address3", employee.Address3);
            parameter.Add("@CityId", employee.CityId);
            parameter.Add("@StateId", employee.StateId);
            parameter.Add("@PinCode", employee.PinCode);
            parameter.Add("@MobileNo", employee.MobileNo);
            parameter.Add("@PhoneNo", employee.PhoneNo);
            parameter.Add("@AdharCardNo", employee.AdharCardNo);
            parameter.Add("@GenderId", employee.GenderId);
            parameter.Add("@EmailId", employee.EmailId);
            parameter.Add("@BirthDate", employee.BirthDate);
            parameter.Add("@JoinDate", employee.JoinDate);
            parameter.Add("@ResignDate", employee.ResignDate);
            parameter.Add("@WeekoffDay", employee.WeekoffDay);
            parameter.Add("@Salary", employee.Salary);
            parameter.Add("@InTime", employee.InTime);
            parameter.Add("@OutTime", employee.OutTime);
            parameter.Add("@AccountId", employee.AccountId);
            parameter.Add("@CommissionOn", employee.CommissionOn);
            parameter.Add("@CommisionPrc", employee.CommisionPrc);
            parameter.Add("@CreatedBy", employee.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                EmployeeList = await connection.QueryAsync<int>("AddEmployee",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return EmployeeList;
        }


        public async Task<IEnumerable<int>> EditEmployee(Employee employee)
        {
            IEnumerable<int> EmployeeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@EmployeeId", employee.EmployeeId);
            parameter.Add("@CompanyId", employee.CompanyId);
            parameter.Add("@BranchId", employee.BranchId);
            parameter.Add("@FirstName", employee.FirstName);
            parameter.Add("@MiddleName", employee.MiddleName);
            parameter.Add("@LastName", employee.LastName);
            parameter.Add("@ShortName", employee.ShortName);
            parameter.Add("@EmployeeCode", employee.EmployeeCode);
            parameter.Add("@DepartmentId", employee.DepartmentId);
            parameter.Add("@DesignationId", employee.DesignationId);
            parameter.Add("@AlloweCompanyId", employee.AlloweCompanyId);
            parameter.Add("@AllowedBranchId", employee.AllowedBranchId);
            parameter.Add("@Address1", employee.Address1);
            parameter.Add("@Address2", employee.Address2);
            parameter.Add("@Address3", employee.Address3);
            parameter.Add("@CityId", employee.CityId);
            parameter.Add("@StateId", employee.StateId);
            parameter.Add("@PinCode", employee.PinCode);
            parameter.Add("@MobileNo", employee.MobileNo);
            parameter.Add("@PhoneNo", employee.PhoneNo);
            parameter.Add("@AdharCardNo", employee.AdharCardNo);
            parameter.Add("@GenderId", employee.GenderId);
            parameter.Add("@EmailId", employee.EmailId);
            parameter.Add("@BirthDate", employee.BirthDate);
            parameter.Add("@JoinDate", employee.JoinDate);
            parameter.Add("@ResignDate", employee.ResignDate);
            parameter.Add("@WeekoffDay", employee.WeekoffDay);
            parameter.Add("@Salary", employee.Salary);
            parameter.Add("@InTime", employee.InTime);
            parameter.Add("@OutTime", employee.OutTime);
            parameter.Add("@AccountId", employee.AccountId);
            parameter.Add("@CommissionOn", employee.CommissionOn);
            parameter.Add("@CommisionPrc", employee.CommisionPrc);
            parameter.Add("@UpdatedBy", employee.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", employee.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                EmployeeList = await connection.QueryAsync<int>("EditEmployee",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return EmployeeList;
        }

        public async Task<IEnumerable<int>> DeleteEmployee(int employeeId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> EmployeeList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@EmployeeId", employeeId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                EmployeeList = await connection.QueryAsync<int>("DeleteUnDeleteEmployee",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return EmployeeList;
        }
    }
}
