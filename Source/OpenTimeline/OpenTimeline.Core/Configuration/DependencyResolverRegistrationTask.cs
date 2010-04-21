using OpenTimeline.Core.InversionOfControl;
using StructureMap;

namespace OpenTimeline.Core.Configuration
{
    public class DependencyResolverRegistrationTask : IContainerRegistrationTask
    {
        #region Implementation of IContainerRegistrationTask

        public void Register()
        {
            ObjectFactory.Configure(x => x.For<IDependencyResolver>().Use<StructureMapDependecyResolver>());
        }

        #endregion
    }
}