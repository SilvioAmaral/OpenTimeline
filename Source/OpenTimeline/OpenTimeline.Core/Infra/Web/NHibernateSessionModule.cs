using System;
using System.Web;
using NHibernate;
using NHibernate.Context;
using OpenTimeline.Core.InversionOfControl;
using OpenTimeline.Core.Lib;

namespace OpenTimeline.Core.Infra.Web
{
    public class NHibernateSessionModule : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        public void Dispose()
        {
        }

        #endregion

        private static void BeginRequest(object sender, EventArgs e)
        {
            var session = IoC.Resolve<ISession>();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }

        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(IoC.Resolve<ISessionFactory>());

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
    }
}