using PlayWeb.DAL;
using PlayWeb.Models.Login;
using SimpleAuthentication.Mvc;
using System.Web;
using System.Web.Mvc;

namespace PlayWeb.Controllers
{
	public class AuthCallbackProvider : IAuthenticationCallbackProvider
	{
		// Returned when successful login authentication is completed.
		public ActionResult Process(HttpContextBase context, AuthenticateCallbackData model)
		{

			// Generate a new user if they haven't logged in before
			UserDAL.GetOrCreateUser(model.AuthenticatedClient.UserInformation.Email);

			return new ViewResult
			{
				ViewName = "LoggedIn",
				ViewData = new ViewDataDictionary(new AuthenticateCallbackViewModel
				{
					AuthenticatedClient = model.AuthenticatedClient,
					Exception = model.Exception,
					ReturnUrl = model.ReturnUrl
				})
			};
		}

		public ActionResult OnRedirectToAuthenticationProviderError(HttpContextBase context, string errorMessage)
		{
			return new ViewResult
			{
				ViewName = "LoginError",
				ViewData = new ViewDataDictionary(new AuthenticationProviderError
				{
					ErrorMessage = errorMessage
				})
			};
		}
	}
}