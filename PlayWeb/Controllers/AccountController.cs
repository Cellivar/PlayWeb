using System.Web;
using System.Web.Http;

namespace PlayWeb.Controllers
{
	public class AccountController : ApiController
	{
		/// <summary>
		/// Log the current user out by abandoning their session.
		/// </summary>
		public void Get(string id)
		{
			if (id == "logout")
			{
				HttpContext.Current.Session.Abandon();
			}
		}

		//// GET api/account
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		//// GET api/account/5
		//public string Get(int id)
		//{
		//	return "value";
		//}

		//// POST api/account
		//public void Post([FromBody]string value)
		//{
		//}

		//// PUT api/account/5
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		//// DELETE api/account/5
		//public void Delete(int id)
		//{
		//}
	}
}
