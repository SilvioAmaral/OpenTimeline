using System;
using System.Web.Mvc;
using System.Web.Routing;
using OpenTimeline.Core.InversionOfControl;

namespace OpenTimeline.Core.Infra.StructureMap
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type controllerType = base.GetControllerType(requestContext, controllerName);
            return IoC.Resolve(controllerType) as IController;
        }
    }
}