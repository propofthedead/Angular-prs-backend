using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prsAngularattempt.Models
{
	public class PurchaseRequest
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Justification { get; set; }
		public string RejectReason { get; set; }
		public string DeliviryMode { get; set; }
		public string Status { get; set; }
		public double Price { get; set; }
		public virtual User User { get; set; }
		public int UserId { get; set; }
		public virtual List<PurchaseRequestLine> PurchaseRequestLines { get; set; }
		public PurchaseRequest() { }
	}
}