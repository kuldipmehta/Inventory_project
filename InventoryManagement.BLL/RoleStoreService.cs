using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using InventoryManagement.Entity.Models;
using InventoryManagement.DAL;

namespace InventoryManagement.BLL.Service
{
    public class RoleStoreService : IRoleStore<ApplicationRole>
    {
        RoleStoreRepository roleStoreRepository = null;

        //public RoleStoreService(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetSection("ConnectionString:InventoryManagementEntities").Value;
        //}


        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            using (roleStoreRepository = new RoleStoreRepository())
            {
                await roleStoreRepository.CreateAsync(role, cancellationToken);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            using (roleStoreRepository = new RoleStoreRepository())
            {
                await roleStoreRepository.UpdateAsync(role, cancellationToken);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            using (roleStoreRepository = new RoleStoreRepository())
            {
                await roleStoreRepository.DeleteAsync(role, cancellationToken);
            }

            return IdentityResult.Success;
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.FromResult(0);
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            using (roleStoreRepository = new RoleStoreRepository())
            {
                return await roleStoreRepository.FindByIdAsync(roleId, cancellationToken);
            }
        }

        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            using (roleStoreRepository = new RoleStoreRepository())
            {
                return await roleStoreRepository.FindByNameAsync(normalizedRoleName, cancellationToken);
            }
        }

        public void Dispose()
        {
            // Nothing to dispose.
        }
    }
}
