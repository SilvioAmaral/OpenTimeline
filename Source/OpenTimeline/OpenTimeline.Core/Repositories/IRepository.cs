using System;
using System.Collections.Generic;

namespace OpenTimeline.Core.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
    }
}