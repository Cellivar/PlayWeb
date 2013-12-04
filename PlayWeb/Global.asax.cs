using Autofac;
using Autofac.Integration.Mvc;
using PlayWeb.Controllers;
using SimpleAuthentication.Core;
using SimpleAuthentication.Mvc;
using SimpleAuthentication.Mvc.Caching;
using System;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace PlayWeb
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			// Create callback resolver for authentication service.. thing
			var builder = new ContainerBuilder();

			builder.RegisterType<AuthCallbackProvider>().As<IAuthenticationCallbackProvider>();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterControllers(typeof(SimpleAuthenticationController).Assembly);
			builder.RegisterType<CookieCache>().As<ICache>();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}

		/// <summary>
		/// The event occurs just after Initialization of Session, and before Page_Init event
		/// </summary>
		protected void Application_PreREquestHandlerExecute(Object sender, EventArgs e)
		{
			// here it checks if session is reuired, as
			// .aspx requires session, and session should be available there
			// .jpg, or .css does require session so session will be null
			// as .jpg, or .css are also http request in either case if you implemented URL Rewritter, or custom IHttp Module
			if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
			{
				Console.WriteLine("Current Session: ");
				Console.Write(Session.IsNewSession);
				Console.Write(Session["User"]);
				if (Session.IsNewSession
					|| Session["User"] == null)
				{
					// checking if request is not for default.aspx page, as it should not be redirected
					if (Context.Request.Url.PathAndQuery.ToLower() != "/")
					{
						//Context.Response.Redirect("~/");
						Console.WriteLine("Derp REDIRECT HAHA");
					}
				}
			}
		}
	}
}