using InventoryManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Interface
{
    public interface IStateService
    {
        Task<IEnumerable<State>> StateList();
        Task<IEnumerable<int>> AddState(State state);
        Task<IEnumerable<int>> EditState(State state);
        Task<IEnumerable<int>> DeleteState(int stateId, bool isActive, int updatedBy, byte[] changeTimeStamp);
    }
}
