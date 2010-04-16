using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;

namespace OpenTimeline.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        #region IRepository<T> Members

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