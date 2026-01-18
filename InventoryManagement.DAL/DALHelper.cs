using Dapper;
using InventoryManagement.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.DAL
{
    public class DALHelper
    {
        public static void CheckAndReturnMessage(DynamicParameters parameter)
        {
            if (parameter.Get<int>("@ReturnValue") == 1001)
            {
                throw new Exception(string.Format("CustomError:{0}",parameter.Get<string>("@ErrorMessage")));
            }
            else if (parameter.Get<int>("@ReturnValue") == 1003)
            {
                throw new Exception(string.Format("CustomError:{0}", GlobalConstant.ValueChangeSinceLastRetriveMessage));
            }  
        }


    }
}
