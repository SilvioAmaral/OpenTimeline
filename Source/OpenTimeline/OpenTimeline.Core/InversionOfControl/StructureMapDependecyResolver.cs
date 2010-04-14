using System;
using System.Collections.Generic;
using StructureMap;

namespace OpenTimeline.Core.InversionOfControl
{
    public class StructureMapDependecyResolver : IDependencyResolver
    {
        public T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}