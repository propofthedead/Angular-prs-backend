using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prsAngularattempt.Models
{
	public class Vendor
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zipcode { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool IsPreApproved { get; set; }
		public bool Active { get; set; }

		public Vendor() { }
	}
}