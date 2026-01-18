using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> UserList();
        Task<IEnumerable<int>> AddUser(ApplicationUser user);
        Task<IEnumerable<int>> EditUser(ApplicationUser user);
        Task<IEnumerable<int>> DeleteUser(int userId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
