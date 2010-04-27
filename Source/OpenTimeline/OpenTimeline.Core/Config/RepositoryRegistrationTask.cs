using OpenTimeline.Core.Domain;
using OpenTimeline.Core.Repositories;
using StructureMap;

namespace OpenTimeline.Core.Config
{
    public class RepositoryRegistrationTask : IContainerRegistrationTask
    {
        #region Implementation of IContainerRegistrationTask

        public void Register()
        {
            ObjectFactory.Configure(x =>
                                        {
                                            x.For<IRepository<Timeline>>().Use<Repository<Timeline>>();
                                            x.For<IRepository<Member>>().Use<Repository<Member>>();
                                            x.For<IRepository<Event>>().Use<Repository<Event>>();
                                            x.For<IRepository<Account>>().Use<Repository<Account>>();
                                            x.For<ITimelineRepository>().Use<TimelineRepository>();
                                        });
        }

        #endregion
    }
}