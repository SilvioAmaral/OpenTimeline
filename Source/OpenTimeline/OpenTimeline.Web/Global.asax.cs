using System.Web.Mvc;
using System.Web.Routing;
using OpenTimeline.Core.Config;
using OpenTimeline.Core.Infra.StructureMap;

namespace OpenTimeline.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "MyTimeline",
                "{controller}/{action}/{timelineId}/{accountId}",
                new {controller = "Account", action = "MyTimeline", timelineId = "", accountId = ""}
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            log4net.Config.XmlConfigurator.Configure();
            RegisterRoutes(RouteTable.Routes);
            new StructureMapApplicationBootstrapper().Configure();
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }
    }
}