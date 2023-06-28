using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Odata.JWT
{
	public class JWTService : IJWTService
	{
		private readonly string SECRETKEY = "The magic key is required to be long enough so I just write some nonsenses here";
		private IHttpContextAccessor _contextAccessor;

		public JWTService(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public bool CheckRole(int role)
		{
			var requestHeader = _contextAccessor.HttpContext.Request.Headers;
			if (requestHeader == null)
			{
				return false;
			}
			else
			{
				string jwtString = requestHeader["Authorization"];

				try
				{
					var token = new JwtSecurityTokenHandler().ReadJwtToken(jwtString);

					int userRole = -1;

					bool tokenRole = int.TryParse(token.Claims.FirstOrDefault(c => c.Type == "UserRole").Value, out userRole);

					if (tokenRole)
					{
						return role == userRole;
					}
					else
					{
						return false;
					}
				}
				catch (Exception ex)
				{
					return false;
				}
					
			}
		}

		public string GenerateToken(User user)
		{
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, user.Username),
				new Claim("UserRole", user.Role.ToString())
			};
			
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRETKEY));

			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
					claims : claims,
					expires : DateTime.UtcNow.AddMinutes(30),
					signingCredentials : credentials
				);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}
	}
}
