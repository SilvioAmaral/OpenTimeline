using System.Web.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using OpenTimeline.Core.AutoMapping;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.Repositories;
using StructureMap;

namespace OpenTimeline.Core.Infra.StructureMap
{
    public class Configuration
    {
        public static void Configure()
        {
            ObjectFactory.Initialize(x =>
                                         {
                                             x.For<ISessionFactory>()
                                                 .Singleton()
                                                 .Use(CreateSessionFactory());

                                             x.For<ISession>()
                                                 .HttpContextScoped()
                                                 .Use(context => context.GetInstance<ISessionFactory>().OpenSession());

                                             x.For<IModelMapper>()
                                                 .Use<AutoMapperModelMapper>();

                                             x.For<IRepository<Timeline>>()
                                                 .Use<Repository<Timeline>>();

                                             x.For<IRepository<Member>>()
                                                 .Use<Repository<Member>>();
                                             //x.Scan(cfg =>
                                             //           {
                                             //               cfg.TheCallingAssembly();
                                             //               cfg.IncludeNamespaceContainingType<Timeline>();
                                             //               cfg.ConnectImplementationsToTypesClosing(
                                             //                   typeof (IRepository<>));
                                             //           });

                                             x.Scan(cfg =>
                                                        {
                                                            cfg.Assembly("OpenTimeline.Web");
                                                            cfg.AddAllTypesOf<IController>();
                                                        });
                                         });
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(
                        conn => conn.FromConnectionStringWithKey("OpenTimelineConn")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Timeline>())
                .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
                .BuildSessionFactory();
        }
    }
}