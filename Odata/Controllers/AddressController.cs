using DataLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Odata.JWT;
using Repository.Entities;

namespace Odata.Controllers
{
	public class AddressController : Controller
	{
		private IJWTService _jwt;
		private IAddressRepository _repository;

		public AddressController(IJWTService jwt, IAddressRepository repository)
		{
			_jwt = jwt;
			_repository = repository;
		}

		[EnableQuery]
		[HttpGet]
		public IActionResult Get()
		{
			if (!(_jwt.CheckRole(1) || _jwt.CheckRole(2)))
			{
				return NotFound();
			}

			return Ok(_repository.GetAll().AsQueryable());
		}

		[HttpPost] 
		public IActionResult Post([FromBody] Address address)
		{
			if (!(_jwt.CheckRole(1) || _jwt.CheckRole(2)))
			{
				return NotFound();
			}

			bool status = true;
			string errorMessage = string.Empty;

			try
			{
				status = _repository.Add(address);
			}catch(Exception ex)
			{
				status = false;
				errorMessage = ex.Message;
			}

			return new JsonResult(new
			{
				status = status,
				errorMessage = errorMessage
			});
		}

		[HttpPatch]
		public IActionResult Patch([FromBody] Address address)
		{
			if (!(_jwt.CheckRole(1) || _jwt.CheckRole(2)))
			{
				return NotFound();
			}

			bool status = true;
			string errorMessage = string.Empty;

			try
			{
				status = _repository.Update(address);
			}
			catch (Exception ex)
			{
				status = false;
				errorMessage = ex.Message;
			}

			return new JsonResult(new
			{
				status = status,
				errorMessage = errorMessage
			});
		}

		[HttpDelete]
		public IActionResult Delete(string key)
		{
			if (!(_jwt.CheckRole(1) || _jwt.CheckRole(2)))
			{
				return NotFound();
			}

			bool status = true;
			string errorMessage = string.Empty;

			try
			{
				status = _repository.Delete(key);
			}
			catch (Exception ex)
			{
				status = false;
				errorMessage = ex.Message;
			}

			return new JsonResult(new
			{
				status = status,
				errorMessage = errorMessage
			});
		}
	}
}
