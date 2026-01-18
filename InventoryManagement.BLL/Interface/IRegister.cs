using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.DAL;
using InventoryManagement.Entity;

namespace InventoryManagement.BLL.Interface
{
	public interface IRegister
    {
        IList<GetRegisterRequestByUserId_Result> GetRegisterRequestByUserId(int userId);
    }
}
