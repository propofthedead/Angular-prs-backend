using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using prsAngularattempt.Models;
using prsAngularattempt.Utility;

namespace prsAngularattempt.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	
	public class LinesController : ApiController
    {
		prscontext db = new prscontext();
		[HttpGet]
		[ActionName("get")]
		public JsonResponse get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = "-3", Message = "the id does not exist", Result = "failed" };
			var l = db.PurchaseLines.Find(id);
			if (l == null)
				return new JsonResponse { Error = "-6", Message = "there is no request Line", Result = "failed" };
			return new JsonResponse { Data = l };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			List<PurchaseRequestLine> lines = db.PurchaseLines.ToList();
			return new JsonResponse { Data = lines };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(PurchaseRequestLine line)
		{
			if (line == null)
				return new JsonResponse { Error = "-4", Message = "Line item is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-3", Message = "the item is not valid", Result = "Failed" };
			db.PurchaseLines.Add(line);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("edit")]
		public JsonResponse edit(PurchaseRequestLine line)
		{
			if (line == null)
				return new JsonResponse { Error = "-4", Message = "Line item is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-3", Message = "the item is not valid", Result = "Failed" };
			var l = db.PurchaseLines.Find(line.Id);
			l.Price = line.Price;
			l.Product = line.Product;
			l.ProductId = line.ProductId;
			l.PurchaseRequest = line.PurchaseRequest;
			l.PurchaseRequestId = line.PurchaseRequestId;
			l.Quantity = line.Quantity;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(PurchaseRequestLine line)
		{
			if (line == null)
				return new JsonResponse { Error = "-4", Message = "Line item is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-3", Message = "the item is not valid", Result = "Failed" };
			PurchaseRequestLine l = db.PurchaseLines.Find(line.Id);
			db.PurchaseLines.Remove(l);
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
