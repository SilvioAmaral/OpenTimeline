using System;
using System.Collections.Generic;

namespace OpenTimeline.Core.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Save(T entity);
        void Delete(T entity);
    }
}