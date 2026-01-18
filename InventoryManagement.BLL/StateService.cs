using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity.Models;

namespace InventoryManagement.BLL.Service
{
    public class StateService : IStateService
    {
        StateRepository stateRepository = null;

        public async Task<IEnumerable<int>> AddState(State state)
        {
            using (stateRepository = new StateRepository())
            {
                return await stateRepository.AddState(state);
            }
        }

        public async Task<IEnumerable<int>> EditState(State state)
        {
            using (stateRepository = new StateRepository())
            {
                return await stateRepository.EditState(state);
            }
        }

        public async Task<IEnumerable<State>> StateList()
        {
            using (stateRepository = new StateRepository())
            {
                return await stateRepository.StateList();
            }
        }

        public async Task<IEnumerable<int>> DeleteState(int stateId, bool isActive, int updatedBy, byte[] changeTimeStamp)
        {
            using (stateRepository = new StateRepository())
            {
                return await stateRepository.DeleteState(stateId, isActive, updatedBy, changeTimeStamp);
            }
        }
    }
}
