using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.BLL.Interface;
using InventoryManagement.DAL;
using InventoryManagement.Entity;
using InventoryManagement.Common;

namespace InventoryManagement.BLL
{
    public class RegisterService : IRegister
    {

        public IList<GetRegisterRequestByUserId_Result> GetRegisterRequestByUserId(int userId)
        {
            RegisterContext Context = null;
            IList<GetRegisterRequestByUserId_Result> _Register = null;
            try
            {
                using (Context = new RegisterContext())
                {
                    _Register = Context.GetRegisterRequestByUserId(userId);
                }
            }
            catch (Exception ex)
            {
               
            }
            return _Register;
        }
    }
}
