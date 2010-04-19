using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace OpenTimeline.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        #region IRepository<T> Members

        public IQueryable<T> Query(Func<IQueryable<T>,IQueryable<T>> filter)
        {
            return filter.Invoke(_session.Linq<T>());
        }

        public IEnumerable<T> FindAll()
        {
            return _session.Linq<T>();
            //return _session.CreateCriteria(typeof (T)).List<T>();
        }

        public T FindById(int id)
        {
            return _session.Load<T>(id);
        }

        #endregion
    }
}