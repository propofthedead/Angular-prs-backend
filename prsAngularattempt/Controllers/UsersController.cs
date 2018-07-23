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
    public class UsersController : ApiController
    {
		private prscontext db = new prscontext();

		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = "-2", Message = "the id is no longer available", Result = "Failed" };
			User u = db.Users.Find(id);
			return new JsonResponse { Data = u };
		}
		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			List<User> users = db.Users.ToList();
			return new JsonResponse { Data = users };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(User user)
		{
			if (user == null)
				return new JsonResponse { Error = "-2", Message = "the user is incomplete", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-2", Message = "the user is incomplete", Result = "Failed" }; ;
			db.Users.Add(user);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("edit")]
		public JsonResponse edit(User user)
		{
			if (user == null)
				return new JsonResponse { Error = "-2", Message = "the user is incomplete", Result = "Failed" }; ;
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-2", Message = "the user is incomplete", Result = "Failed" }; ;
			var u = db.Users.Find(user.Id);
			u.Username = user.Username;
			u.Firstname = user.Firstname;
			u.Lastname = user.Lastname;
			u.Password = user.Password;
			u.Phone = user.Phone;
			u.Email = user.Email;
			u.IsAdmin = user.IsAdmin;
			u.IsReviewer = user.IsReviewer;
			u.Active = user.Active;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(User user)
		{
			if (user == null)
				return new JsonResponse { Error = "-2", Message = "the user is incomplete", Result = "Failed" }; ;
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "-2", Message = "the user is incomplete", Result = "Failed" }; ;
			var u = db.Users.Find(user.Id);
			db.Users.Remove(u);
			db.SaveChanges();
			return new JsonResponse();
		}
		[HttpGet]
		[ActionName("authenticate")]
		public JsonResponse login(string password, string username)
		{
			if (password == null || username == null)
				return new JsonResponse { Error = "-3", Message = "the username or password is wrong", Result = "Failed" };
			var user = db.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
			if (user==null)
				return new JsonResponse { Error = "-2", Message = "the user is incomplete", Result = "Failed" }; ;
			return new JsonResponse { Data = user };
		}
    }
}
