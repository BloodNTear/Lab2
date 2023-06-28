using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
	public interface IAddressRepository
	{
		List<Address> GetAll();
		bool Add(Address address);
		bool Update(Address address);
		bool Delete(string city);
	}
}
