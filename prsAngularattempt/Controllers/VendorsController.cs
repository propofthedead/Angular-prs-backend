using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using prsAngularattempt.Models;
using prsAngularattempt.Utility;

namespace prsAngularattempt.Controllers
{
	public class VendorsController : ApiController
	{
		private prscontext db = new prscontext();

		[HttpGet]
		[ActionName("get")]
		public JsonResponse get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = "-2", Message = "the id is null", Result = "Failed" }; ;
			var v = db.Vendors.Find(id);
			return new JsonResponse { Data = v };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			var vendors = db.Vendors.ToList();
			return new JsonResponse { Data = vendors };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(Vendor vendor)
		{
			if (vendor == null)
				return new JsonResponse { Error = "-2", Message = "the vendor is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-3", Message = "the vendor is not valid in format", Result = "Failed" };
			db.Vendors.Add(vendor);
			db.SaveChanges();
			return new JsonResponse();
		}
		[HttpPost]
		[ActionName("edit")]
		public JsonResponse edit(Vendor vendor)
		{
			if (vendor == null)
				return new JsonResponse { Error = "-2", Message = "the vendor is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-3", Message = "the vendor is not valid in format", Result = "Failed" };
			var v = db.Vendors.Find(vendor.Id);
			v.Active = vendor.Active;
			v.Address = vendor.Address;
			v.City = vendor.City;
			v.Code = vendor.Code;
			v.Email = vendor.Email;
			v.IsPreApproved = vendor.IsPreApproved;
			v.Name = vendor.Name;
			v.Phone = vendor.Phone;
			v.State = vendor.State;
			v.Zipcode = vendor.Zipcode;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(Vendor vendor)
		{
			if (vendor == null)
				return new JsonResponse { Error = "-2", Message = "the vendor is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-2", Message = "the vendor is invalid", Result = "failed" };
			var v = db.Vendors.Find(vendor.Id);
			if (v == null)
				return new JsonResponse { Error = "3", Message = "Vendor is not in the data base", Result = "failed" };
			db.Vendors.Remove(v);
			db.SaveChanges();
			return new JsonResponse();
		}

    }
}
