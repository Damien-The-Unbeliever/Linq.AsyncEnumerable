using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Filters the elements of an <see cref="IAsyncEnumerable{T}"/> based on the specified type
    /// </summary>
    /// <typeparam name="TSource">The basic type of elements contained in the sequence</typeparam>
    /// <typeparam name="TResult">The type of elements desired in the result</typeparam>
    /// <param name="source">The sequence of elements to filter</param>
    /// <returns>A sequence of elements that are <typeparamref name="TResult"/></returns>
    public static IAsyncEnumerable<TResult> OfType<TSource, TResult>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return OfTypeInternal<TSource,TResult>(source);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> OfTypeInternal<TSource,TResult>(
      this IAsyncEnumerable<TSource> source)
    {
      await foreach(var original in source)
      {
        if(original is TResult ofType)
        {
          yield return ofType;
        }
      }
    }
    #endregion
  }
}
