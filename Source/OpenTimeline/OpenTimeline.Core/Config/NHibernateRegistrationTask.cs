using NHibernate;
using OpenTimeline.Core.NHibernate;
using StructureMap;

namespace OpenTimeline.Core.Config
{
    public class NHibernateRegistrationTask : IContainerRegistrationTask
    {
        #region Implementation of IContainerRegistrationTask

        public void Register()
        {
            ObjectFactory.Configure(x =>
                                        {
                                            x.For<ISessionFactory>()
                                                .Singleton()
                                                .Use(SessionFactoryConfig.CreateSessionFactory());

                                            x.For<ISession>()
                                                .HttpContextScoped()
                                                .Use(context => context.GetInstance<ISessionFactory>().OpenSession());
                                        });
        }

        #endregion
    }
}