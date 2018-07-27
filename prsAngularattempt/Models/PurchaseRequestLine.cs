using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prsAngularattempt.Models
{
	public class PurchaseRequestLine
	{
		public int Id { get; set; }
		public int PurchaseRequestId { get; set; }
		public virtual PurchaseRequest PurchaseRequest { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		public PurchaseRequestLine() { }
	}
}