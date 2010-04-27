using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace OpenTimeline.Core.Tests
{
    public class InMemoryDatabaseTest : IDisposable
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;
        protected ISession _session;

        public InMemoryDatabaseTest(Assembly assemblyContainingMappedType)
        {
            if (_configuration == null)
                _sessionFactory = CreateSessionFactory(assemblyContainingMappedType);

            _session = _sessionFactory.OpenSession();

            new SchemaExport(_configuration).Execute(true, true, false, _session.Connection, Console.Out);
        }

        private static ISessionFactory CreateSessionFactory(Assembly assemblyContainingMappedType)
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory)
                .Mappings(m => m.FluentMappings.AddFromAssembly(assemblyContainingMappedType))
                .ExposeConfiguration(cfg => _configuration = cfg)
                .BuildSessionFactory();
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}