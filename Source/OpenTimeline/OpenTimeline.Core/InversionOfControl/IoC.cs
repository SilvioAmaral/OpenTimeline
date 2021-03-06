using System;

namespace OpenTimeline.Core.InversionOfControl
{
    public class IoC
    {
        private static IDependencyResolver _resolver;

        public static void Initialize(IDependencyResolver dependencyResolver)
        {
            _resolver = dependencyResolver;
        }

        public static T Resolve<T>()
        {
            return _resolver.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return _resolver.Resolve(type);
        }
    }
}