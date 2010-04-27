using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using OpenTimeline.Core.Domain;

namespace OpenTimeline.Core.NHibernate
{
    public static class SessionFactoryConfig
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(
                        conn => conn.FromConnectionStringWithKey("OpenTimelineConn")).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Timeline>())
                .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
                .BuildSessionFactory();
        }
    }
}