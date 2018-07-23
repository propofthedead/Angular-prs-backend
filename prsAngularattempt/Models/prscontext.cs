using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prsAngularattempt.Models
{
	public class prscontext : DbContext
	{

		public prscontext() : base() { }

		public DbSet<User> Users { get; set; }
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Product> Products { get; set; }

	}
}