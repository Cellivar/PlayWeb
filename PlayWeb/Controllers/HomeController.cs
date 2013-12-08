using System.Web.Mvc;

namespace PlayWeb.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/

		//public ActionResult Index()
		//{
		//	return View();
		//}

		/// <summary>
		/// Log user out on navigation to ~/logout
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Index(string id)
		{
			if (id == "logout")
			{
				System.Web.HttpContext.Current.Session.Clear();
				System.Web.HttpContext.Current.Session.Abandon();
			}

			return View();
		}

	}
}
