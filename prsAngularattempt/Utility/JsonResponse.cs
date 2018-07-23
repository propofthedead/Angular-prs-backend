using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prsAngularattempt.Utility
{
	public class JsonResponse
	{
		public string Message { get; set; } = "Sucess";
		public string Result { get; set; } = "ok";
		public object Data { get; set; }
		public object Error { get; set; }
	}
}