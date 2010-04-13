using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace OpenTimeline.Core.Infra.StructureMap
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}