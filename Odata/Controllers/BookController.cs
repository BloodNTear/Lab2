using DataLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Odata.JWT;
using Repository.Entities;

namespace Odata.Controllers
{
    public class BookController : Controller
    {
        IBookRepository _repository;
        IJWTService _jwt;

		public BookController(IBookRepository repository, IJWTService jwt)
		{
			_repository = repository;
			_jwt = jwt;
		}

		[EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            if(_jwt.CheckRole(1) || _jwt.CheckRole(2))
            {
				return Ok(_repository.GetAll().AsQueryable());
            }
            else
            {
                return Unauthorized();
            }
        }

        [EnableQuery]
        [HttpDelete]
        public IActionResult Delete(Guid key) {

            if (_jwt.CheckRole(1))
            {
                bool status = false;
                string errorMessage = string.Empty;  
                try
                {
				     status = _repository.Delete(key);
				}catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }

				return new JsonResult(new
				{
					status = status,
                    errorMessage = errorMessage
				});
			}
            else
            {
                return Unauthorized();
            }
		}

        [HttpPatch]
        public IActionResult Patch([FromBody] Book book)
        {
            bool status = true;
            string errorMessage = string.Empty;

            if (!(_jwt.CheckRole(1) || _jwt.CheckRole(2)))
            {
                return Unauthorized();
            }

            try
            {
                status = _repository.Update(book);
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

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            bool status = true;
            string errorMessage = string.Empty;

            if (!_jwt.CheckRole(1))
            {
                return Unauthorized(true);
            }

            try
            {
                book.ID = Guid.NewGuid();

                status = _repository.Create(book);
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
    }
}
