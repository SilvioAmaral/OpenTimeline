using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OpenTimeline.Core.Lib;

namespace OpenTimeline.Core.AutoMapping
{
    public class AutoMapperModelMapper : IModelMapper
    {
        #region Implementation of IModelMapper

        public TResult Map<TSource, TResult>(TSource source)
        {
            return Mapper.Map<TSource, TResult>(source);
        }

        public IEnumerable<TResult> MapAll<TSource, TResult>(IEnumerable<TSource> sourceEnumerable)
        {
            return sourceEnumerable.IsNullOrEmpty()
                       ? Enumerable.Empty<TResult>()
                       : sourceEnumerable.Select(Mapper.Map<TSource, TResult>);
        }

        #endregion
    }
}