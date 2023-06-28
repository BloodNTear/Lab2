using DataLayer.Interface;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Odata.JWT;
using Odata.Models;

namespace Odata.Controllers
{
	public class AccountController : Controller
	{
		private IUserRepository _userRepository;
		private IJWTService _jwt;

		public AccountController(IUserRepository userRepository, IJWTService jwt)
		{
			_userRepository = userRepository;
			_jwt = jwt;
		}

		[HttpPost]
		public IActionResult Post([FromBody] LoginModel loginModel)
		{
			var user = _userRepository.Login(loginModel.Username, loginModel.Password);
			if (user == null)
			{
				return new JsonResult(new
				{
					status = false,
					errorMessage = "Invalid username or password"
				});
			}
			else
			{
				var token = _jwt.GenerateToken(user);
				return new JsonResult(new
				{
					status = true,
					AccessToken = token
				});
			}
		}
	}
}
