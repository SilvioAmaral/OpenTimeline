using System;
using StructureMap;

namespace OpenTimeline.Core.InversionOfControl
{
    public class StructureMapDependecyResolver : IDependencyResolver
    {
        #region IDependencyResolver Members

        public T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }

        public object Resolve(Type type)
        {
            return ObjectFactory.GetInstance(type);
        }

        #endregion
    }
}