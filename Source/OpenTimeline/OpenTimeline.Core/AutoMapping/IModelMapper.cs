using System.Collections.Generic;

namespace OpenTimeline.Core.AutoMapping
{
    public interface IModelMapper
    {
        TResult Map<TSource, TResult>(TSource source);
        IEnumerable<TResult> MapAll<TSource, TResult>(IEnumerable<TSource> sourceEnumerable);
    }
}