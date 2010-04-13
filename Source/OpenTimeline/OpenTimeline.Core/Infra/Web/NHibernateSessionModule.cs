using System;
using System.Web;
using NHibernate;
using NHibernate.Context;
using OpenTimeline.Core.Lib;
using StructureMap;

namespace OpenTimeline.Core.Infra.Web
{
    public class NHibernateSessionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        private static void BeginRequest(object sender, EventArgs e)
        {
            var session = ObjectFactory.GetInstance<ISession>();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }

        private static void EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(ObjectFactory.GetInstance<ISessionFactory>());

            if (session.IsNull()) return;
            
            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }

        public void Dispose()
        {
        }
    }
}