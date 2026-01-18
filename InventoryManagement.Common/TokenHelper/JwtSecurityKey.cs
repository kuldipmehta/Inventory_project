using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManagement.Common.TokenHelper
{
  public static class JwtSecurityKey
  {
    public static SymmetricSecurityKey Create()
    {
      return new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fiver-secret-key"));
    }
  }
}
