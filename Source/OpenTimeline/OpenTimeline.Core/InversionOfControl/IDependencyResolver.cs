using System;

namespace OpenTimeline.Core.InversionOfControl
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
        object Resolve(Type type);
    }
}