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
	public class AddressRepository : IAddressRepository
	{
		private DatabaseContext _dbContext;
		private DbSet<Address> _addresses;

		public AddressRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
			_addresses = dbContext.Addresses;
		}

		public bool Add(Address address)
		{
			_addresses.Add(address);
			return _dbContext.SaveChanges() > 0;
		}

		public bool Delete(string city)
		{
			var target = _addresses.FirstOrDefault(addr => addr.City == city);
			if (target == null)
			{
				return false;
			}
			else
			{
				_addresses.Remove(target);
				return _dbContext.SaveChanges() > 0;
			}
		}

		public List<Address> GetAll()
		{
			return _addresses.Include(address => address.Books).ToList();
		}

		public bool Update(Address address)
		{
			var target = _addresses.FirstOrDefault(addr => addr.City == address.City);
			if (target == null)
			{
				return false;
			}
			else
			{
				target.City = address.City;
				_addresses.Update(target);
				return _dbContext.SaveChanges() > 0;
			}
		}
	}
}
