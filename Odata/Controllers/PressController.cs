using DataLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Odata.JWT;
using Repository.Entities;

namespace Odata.Controllers
{
	public class PressController : Controller
	{
		private IPressRepository _repository;
		private IJWTService _jwt;

		public PressController(IPressRepository repository, IJWTService jwt)
		{
			_repository = repository;
			_jwt = jwt;
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

		[HttpDelete]
		public IActionResult Delete(Guid key)
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

		[HttpPost] 
		public IActionResult Post([FromBody] Press press)
		{
			bool status = true;
			string errorMessage = string.Empty;

			if(!(_jwt.CheckRole(1) || _jwt.CheckRole(2)))
			{
				return NotFound();
			}

			try
			{
				press.ID = Guid.NewGuid();
				status = _repository.Add(press);
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
		public IActionResult Patch([FromBody] Press press)
		{
			bool status = true;
			string errorMessage = string.Empty;

			if (!(_jwt.CheckRole(1) || _jwt.CheckRole(2)))
			{
				return NotFound();
			}

			try
			{
				status = _repository.Update(press);
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
