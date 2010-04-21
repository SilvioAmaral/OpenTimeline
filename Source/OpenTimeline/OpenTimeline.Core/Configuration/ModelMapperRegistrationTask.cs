using OpenTimeline.Core.AutoMapping;
using StructureMap;

namespace OpenTimeline.Core.Configuration
{
    public class ModelMapperRegistrationTask : IContainerRegistrationTask
    {
        #region Implementation of IContainerRegistrationTask

        public void Register()
        {
            ObjectFactory.Configure(x => x.For<IModelMapper>().Use<AutoMapperModelMapper>());
        }

        #endregion
    }
}