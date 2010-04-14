using System.Collections.Generic;

namespace OpenTimeline.Core.InversionOfControl
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
    }
}