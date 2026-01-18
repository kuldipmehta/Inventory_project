using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class UserService : IUserService
    {
        UserRepository userRepository = null;

        public async Task<IEnumerable<int>> AddUser(ApplicationUser user)
        {
            using (userRepository = new UserRepository())
            {
                return await userRepository.AddUser(user);
            }
        }

        public async Task<IEnumerable<int>> EditUser(ApplicationUser user)
        {
            using (userRepository = new UserRepository())
            {
                return await userRepository.EditUser(user);
            }
        }

        public async Task<IEnumerable<ApplicationUser>> UserList()
        {
            using (userRepository = new UserRepository())
            {
                return await userRepository.UserList();
            }
        }

        public async Task<IEnumerable<int>> DeleteUser(int userId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (userRepository = new UserRepository())
            {
                return await userRepository.DeleteUser(userId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }
}
