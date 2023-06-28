using DataLayer.Interface;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implement
{
	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _context;
		private DbSet<User> _dbSet;

		public UserRepository(DatabaseContext context)
		{
			_context = context;
			_dbSet = _context.Users;
		}

		public User Login(string username, string password)
		{
			return _dbSet.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
		}
	}
}
