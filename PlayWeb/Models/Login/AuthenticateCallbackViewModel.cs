using PlayWeb.DAL;
using System;
using System.Web;

namespace PlayWeb.Models.Login
{
	public class AuthenticateCallbackViewModel
	{
		public Exception Exception { get; set; }
		public string ReturnUrl { get; set; }
		public User User { get; set; }
		public HttpContextBase Context { get; set; }
	}
}