using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace OpenTimeline.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected readonly ISession Session;

        public Repository(ISession session)
        {
            Session = session;
        }

        #region IRepository<T> Members

        public IQueryable<T> Query(Func<IQueryable<T>,IQueryable<T>> filter)
        {
            return filter.Invoke(Session.Linq<T>());
        }

        public IEnumerable<T> FindAll()
        {
            return Session.Linq<T>();
            //return _session.CreateCriteria(typeof (T)).List<T>();
        }

        public T FindById(int id)
        {
            return Session.Load<T>(id);
        }

        public void Save(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        #endregion
    }
}