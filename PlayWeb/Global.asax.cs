using Autofac;
using Autofac.Integration.Mvc;
using PlayWeb.Controllers;
using SimpleAuthentication.Core;
using SimpleAuthentication.Mvc;
using SimpleAuthentication.Mvc.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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
	}
}