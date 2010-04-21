using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using OpenTimeline.Core.Domain;
using StructureMap;

namespace OpenTimeline.Core.Configuration
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
                                                .Use(CreateSessionFactory());

                                            x.For<ISession>()
                                                .HttpContextScoped()
                                                .Use(context => context.GetInstance<ISessionFactory>().OpenSession());
                                        });
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(
                        conn => conn.FromConnectionStringWithKey("OpenTimelineConn")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Timeline>())
                .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
                .BuildSessionFactory();
        }

        #endregion
    }
}