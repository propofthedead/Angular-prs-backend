using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using prsAngularattempt.Utility;
using prsAngularattempt.Models;

namespace prsAngularattempt.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]

	public class PurchaseRequestsController : ApiController
    {
		prscontext db = new prscontext();

		[HttpGet]
		[ActionName("detail")]
		public JsonResponse detail(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = "-3", Message = "The id value is null", Result = "Failed" };
			var r = db.Requests.Find(id);
			if (r == null)
				return new JsonResponse { Error = "-4", Message = "there is no object", Result = "Failed" };
			return new JsonResponse { Data = r };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			var requests = db.Requests.ToList();
			return new JsonResponse { Data = requests };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(PurchaseRequest request)
		{
			if (request == null)
				return new JsonResponse { Error = "-3", Message = "The request is nullable", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-4", Message = "The object is not a request", Result = "failed" };
			db.Requests.Add(request);
			db.SaveChanges();
			return new JsonResponse();

		}

		[HttpPost]
		[ActionName("edit")]
		public JsonResponse edit(PurchaseRequest request)
		{
			if(request == null)
				return new JsonResponse { Error = "-3", Message = "The request is nullable", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-4", Message = "The object is not a request", Result = "failed" };
			var r = db.Requests.Find(request.Id);
			if(r==null)
				return new JsonResponse { Error = "-3", Message = "The request is nullable", Result = "Failed" };
			r.DeliviryMode = request.DeliviryMode;
			r.Description = request.Description;
			r.Justification = request.Justification;
			r.Price = request.Price;
			r.RejectReason = request.RejectReason;
			r.Status = request.Status;
			r.User = request.User;
			r.UserId = request.UserId;
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
