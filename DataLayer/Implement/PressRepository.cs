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
	public class PressRepository : IPressRepository
	{
		private DatabaseContext _dbContext;
		private DbSet<Press> _presss;

		public PressRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
			_presss = dbContext.Presses;
		}

		public List<Press> GetAll()
		{
			return _presss.Include(press => press.Books).ToList();
		}

		public bool Delete(Guid key)
		{
			var press = _presss.FirstOrDefault(x => x.ID == key);
			if (press == null)
			{
				return false;
			}

			_presss.Remove(press);
			_dbContext.SaveChanges();
			return true;
		}

		public bool Add(Press press)
		{

			_presss.Add(press);
			_dbContext.SaveChanges();
			return true;
		}

		public bool Update(Press press)
		{
			_presss.Update(press);
			_dbContext.SaveChanges();
			return true;
		}
	}
}
