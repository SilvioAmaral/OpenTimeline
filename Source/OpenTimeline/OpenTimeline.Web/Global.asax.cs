using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OpenTimeline.Core.Infra.StructureMap;
using OpenTimeline.Core.InversionOfControl;

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
                "MyTimeline",
                "{controller}/{action}/{timelineId}/{accountId}",
                new { controller = "Account", action = "MyTimeline", timelineId = "", accountId = "" }
                );
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            OpenTimeline.Core.Infra.StructureMap.Configuration.Configure();
            IoC.Initialize(new StructureMapDependecyResolver());
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }
    }
}