using SimpleAuthentication.Core;
using System;

namespace PlayWeb.Models.Login
{
	public class AuthenticateCallbackViewModel
	{
		public IAuthenticatedClient AuthenticatedClient { get; set; }
		public Exception Exception { get; set; }
		public string ReturnUrl { get; set; }
	}
}