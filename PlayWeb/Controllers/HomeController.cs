using System.Web.Mvc;

namespace PlayWeb.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// Log user out on navigation to ~/logout
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Index(string id)
		{
			ActionResult action;

			if (id == "logout")
			{
				System.Web.HttpContext.Current.Session.Clear();
				System.Web.HttpContext.Current.Session.Abandon();
				// Keep URLs clean
				action = new RedirectResult("~/");
			}
			else
			{
				action = View();
			}

			return action;
		}

	}
}
