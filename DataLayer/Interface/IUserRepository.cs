﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
	public interface IUserRepository
	{
		User Login(string username, string password);
	}
}
