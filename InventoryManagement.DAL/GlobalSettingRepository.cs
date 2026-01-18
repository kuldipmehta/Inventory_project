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
using System.Linq;

namespace InventoryManagement.DAL
{
    public class GlobalSettingRepository : BaseRepository
    {
        private IEnumerable<int> globalSettingList;

        public async Task<GlobalSetting> GlobalSetting(bool isActive = true)
        {
            IEnumerable<GlobalSetting> globalSettingList;

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                globalSettingList = await connection.QueryAsync<GlobalSetting>("GetGlobalSettingDetails",
                                                                                commandType: CommandType.StoredProcedure);
            }
            return globalSettingList.FirstOrDefault();
        }

        public async Task<IEnumerable<int>> UpdateGlobalSetting(GlobalSetting globalSetting)
        {
            IEnumerable<int> globalSettingList;

            #region Parameter
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@GlobalSettingId", globalSetting.GlobalSettingId);
            parameter.Add("@SiteName", globalSetting.SiteName);
            parameter.Add("@CurrentSiteUrl", globalSetting.CurrentSiteUrl);
            parameter.Add("@Logo", globalSetting.Logo);
            parameter.Add("@Favicon", globalSetting.Favicon);
            parameter.Add("@SiteTagLine", globalSetting.SiteTagLine);
            parameter.Add("@SiteFooter", globalSetting.SiteFooter);
            parameter.Add("@ReceivedOnEmail", globalSetting.ReceivedOnEmail);
            parameter.Add("@SendFromEmail", globalSetting.SendFromEmail);
            parameter.Add("@SMTP", globalSetting.SMTP);
            parameter.Add("@Password", globalSetting.Password);
            parameter.Add("@Port", globalSetting.Port);
            parameter.Add("@SSL", globalSetting.SSL);
            parameter.Add("@PathToFolder", globalSetting.PathToFolder);
            parameter.Add("@ListLimit", globalSetting.ListLimit);
            parameter.Add("@UpdatedBy", globalSetting.UpdatedBy);
            parameter.Add("@ChangeTimeStamp", globalSetting.ChangeTimeStamp);
            parameter.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameter.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            #endregion

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                globalSettingList = await connection.QueryAsync<int>("UpdateGlobalSetting",
                                                            parameter,
                                                            commandType: CommandType.StoredProcedure);
                DALHelper.CheckAndReturnMessage(parameter);
            }
            return globalSettingList;
        }
    }
}
