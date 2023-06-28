using DataLayer.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implement
{
	public class BookRepository : IBookRepository
	{
		private readonly DatabaseContext _context;
		private DbSet<Book> _entity;

		public BookRepository(DatabaseContext context)
		{
			_context = context;
			_entity = _context.Books;
		}

		public bool Create(Book book)
		{
			_entity.Add(book);
			return _context.SaveChanges() > 0;
		}

		public bool Delete(Guid key)
		{
			var book = _entity.Find(key);
			if (book != null)
			{
				_entity.Remove(book);
				return _context.SaveChanges() > 0;
			}
			else
			{
				return false;
			}
		}

		public List<Book> GetAll()
		{
			var result = _entity.Include(book => book.Press).Include(book => book.Address).ToList();

			return result;
		}

		public bool Update(Book book)
		{
			var target = _entity.FirstOrDefault(b => b.ID.Equals(book.ID));
			if (target != null)
			{
				target.Title = book.Title;
				target.Author = book.Author;
				target.ISBN = book.ISBN;
				target.Price = book.Price;
				target.PressId = book.PressId;
				target.AddressCity = book.AddressCity;

				_entity.Update(target);
				return _context.SaveChanges() > 0;
			}
			else
			{
				return false;
			}
		}
	}
}
