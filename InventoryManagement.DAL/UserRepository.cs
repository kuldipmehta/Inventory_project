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
    public class UserRepository : BaseRepository
    {
        public async Task<IEnumerable<ApplicationUser>> UserList(bool IsActive = true)
        {
            IEnumerable<ApplicationUser> userList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                userList = await connection.QueryAsync<ApplicationUser>("GetUserDetails",
                                                                        new { IsActive },
                                                                        commandType: CommandType.StoredProcedure);
            }
            return userList;
        }

        public async Task<IEnumerable<int>> AddUser(ApplicationUser user)
        {
            IEnumerable<int> userList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@UserName", user.UserName);
            parameter.Add("@NormalizedUserName", user.UserName.ToUpper());
            parameter.Add("@Email", user.Email);
            parameter.Add("@NormalizedEmail", user.Email.ToUpper());
            parameter.Add("@EmailConfirmed", user.EmailConfirmed);
            parameter.Add("@PasswordHash", user.PasswordHash);
            parameter.Add("@PhoneNumber", user.PhoneNumber);
            parameter.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
            parameter.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
            parameter.Add("@RoleId", user.RoleId);
            parameter.Add("@Address", user.Address);
            parameter.Add("@AdharCardNo", user.AdharCardNo);
            parameter.Add("@AllowedCompanyID", user.AllowedCompanyID);
            parameter.Add("@AllowedBranchID", user.AllowedBranchID);
            parameter.Add("@LoginCompanyID", user.LoginCompanyID);
            parameter.Add("@LoginBranchID", user.LoginBranchID);
            parameter.Add("@DefaultLastFinancialYearID", user.DefaultLastFinancialYearID);
            parameter.Add("@AllowedListingDays", user.AllowedListingDays);
            parameter.Add("@AllowedDiscountLimitPrc", user.AllowedDiscountLimitPrc);
            parameter.Add("@PreviousDateEntryDays", user.PreviousDateEntryDays);
            parameter.Add("@PurchaseRateShow", user.PurchaseRateShow);
            parameter.Add("@AllUserDataShow", user.AllUserDataShow);
            parameter.Add("@AllowedDayBookID", user.AllowedDayBookID);
            parameter.Add("@UserImage", user.UserImage);
            parameter.Add("@CreatedBy", user.CreatedBy);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                userList = await connection.QueryAsync<int>("AddUser",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);

            }
            return userList;
        }

        public async Task<IEnumerable<int>> EditUser(ApplicationUser user)
        {
            IEnumerable<int> userList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@UserId", user.Id);
            parameter.Add("@UserName", user.UserName);
            parameter.Add("@NormalizedUserName", user.NormalizedUserName);
            parameter.Add("@Email", user.Email);
            parameter.Add("@NormalizedEmail", user.NormalizedEmail);
            parameter.Add("@EmailConfirmed", user.EmailConfirmed);
            parameter.Add("@PasswordHash", user.PasswordHash);
            parameter.Add("@PhoneNumber", user.PhoneNumber);
            parameter.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
            parameter.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
            parameter.Add("@RoleId", user.RoleId);
            parameter.Add("@Address", user.Address);
            parameter.Add("@AdharCardNo", user.AdharCardNo);
            parameter.Add("@AllowedCompanyID", user.AllowedCompanyID);
            parameter.Add("@AllowedBranchID", user.AllowedBranchID);
            parameter.Add("@LoginCompanyID", user.LoginCompanyID);
            parameter.Add("@LoginBranchID", user.LoginBranchID);
            parameter.Add("@DefaultLastFinancialYearID", user.DefaultLastFinancialYearID);
            parameter.Add("@AllowedListingDays", user.AllowedListingDays);
            parameter.Add("@AllowedDiscountLimitPrc", user.AllowedDiscountLimitPrc);
            parameter.Add("@PreviousDateEntryDays", user.PreviousDateEntryDays);
            parameter.Add("@PurchaseRateShow", user.PurchaseRateShow);
            parameter.Add("@AllUserDataShow", user.AllUserDataShow);
            parameter.Add("@AllowedDayBookID", user.AllowedDayBookID);
            parameter.Add("@UserImage", user.UserImage);
            parameter.Add("@UpdatedBy", user.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", user.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output,size:100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                userList = await connection.QueryAsync<int>("EditUser",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return userList;
        }

        public async Task<IEnumerable<int>> DeleteUser(int userId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            IEnumerable<int> userList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@UserId", userId);
            parameter.Add("@IsActive", isActive);
            parameter.Add("@UpdatedBy", updatedBy);
            parameter.Add("@ChangeTimeStamp", changeTimeStamp);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                userList = await connection.QueryAsync<int>("DeleteUnDeleteUser",
                                                             parameter,
                                                             commandType: CommandType.StoredProcedure);

                DALHelper.CheckAndReturnMessage(parameter);
            }
            return userList;
        }
    }
}
