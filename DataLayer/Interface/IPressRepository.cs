using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
	public interface IPressRepository
	{
		List<Press> GetAll();
		public bool Delete(Guid key);
		public bool Add(Press press);
		public bool Update(Press press);	
	}
}
