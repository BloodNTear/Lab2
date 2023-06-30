using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Login()
		{
			return View("Login");
		}

		public IActionResult EditPresses()
		{
			return View("PressList");
		}

		public IActionResult EditAddresses()
		{
			return View("AddressList");
		}

		public IActionResult BookList()
		{
			return View("BookList");
		}

		public IActionResult CustomerView()
		{
			return View("CustomerView");
		}
	}
}
