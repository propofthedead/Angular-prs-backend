using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prsAngularattempt.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string  PartNumber { get; set; }
		public string Unit { get; set; }
		public double Price { get; set;}
		public string PhotoPath { get; set; }
		public virtual Vendor Vendor { get; set; }
		public int VendorId { get; set; }


		public Product() { }
	}
}