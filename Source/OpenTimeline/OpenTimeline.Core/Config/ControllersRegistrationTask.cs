using System.Web.Mvc;
using StructureMap;

namespace OpenTimeline.Core.Config
{
    public class ControllersRegistrationTask : IContainerRegistrationTask
    {
        #region Implementation of IContainerRegistrationTask

        public void Register()
        {
            ObjectFactory.Configure(x => x.Scan(cfg =>
                                                    {
                                                        cfg.Assembly("OpenTimeline.Web");
                                                        cfg.AddAllTypesOf<IController>();
                                                    }));
                
        }

        #endregion
    }
}