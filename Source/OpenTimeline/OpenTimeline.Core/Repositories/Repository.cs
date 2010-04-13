using System.Collections.Generic;
using NHibernate;

namespace OpenTimeline.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<T> FindAll()
        {
            return _session.CreateCriteria(typeof(T)).List<T>();
        }
    }
}