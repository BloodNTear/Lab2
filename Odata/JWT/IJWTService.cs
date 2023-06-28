using DataLayer.Models;

namespace Odata.JWT
{
	public interface IJWTService
	{
		string GenerateToken(User user);
		public bool CheckRole(int role);
	}
}
