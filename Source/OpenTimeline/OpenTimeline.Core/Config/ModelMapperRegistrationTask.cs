using OpenTimeline.Core.AutoMapping;
using StructureMap;

namespace OpenTimeline.Core.Config
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