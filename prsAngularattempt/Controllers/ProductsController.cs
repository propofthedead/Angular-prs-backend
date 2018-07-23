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
    public class ProductsController : ApiController
    {
		prscontext db = new prscontext();

		[HttpGet]
		[ActionName("get")]
		public JsonResponse get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = "-3", Message = "The id value is null", Result = "Failed" };
			var p = db.Products.Find(id);
			if (p == null) {
				return new JsonResponse { Error = "-4", Message = "this is an invalid product", Result = "Failed" };
			}
			return new JsonResponse { Data = p };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			var p = db.Products.ToList();
			return new JsonResponse { Data = p };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create( Product product)
		{
			if (product == null)
				return new JsonResponse { Error = "-3", Message = "the product is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-4", Message = "the product is invalid", Result = "Failed" };
			db.Products.Add(product);
			db.SaveChanges();
			return new JsonResponse();
		}
		[HttpPost]
		[ActionName("edit")]
		public JsonResponse edit(Product product)
		{
			if (product == null)
				return new JsonResponse { Error = "-3", Message = "the product is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-4", Message = "the product is invalid", Result = "Failed" };
			var p = db.Products.Find(product.Id);
			p.Name = product.Name;
			p.PartNumber = product.PartNumber;
			p.PhotoPath = product.PhotoPath;
			p.Price = p.Price;
			p.Unit = p.Unit;
			p.Vendor = p.Vendor;
			p.VendorId = p.VendorId;
			db.SaveChanges();
			return new JsonResponse();
		}
		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(Product product)
		{
			if (product == null)
				return new JsonResponse { Error = "-3", Message = "the product is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-4", Message = "the product is invalid", Result = "Failed" };
			var p = db.Products.Find(product.Id);
			db.Products.Remove(p);
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
