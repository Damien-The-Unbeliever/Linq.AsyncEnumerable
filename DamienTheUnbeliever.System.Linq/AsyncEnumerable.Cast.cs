using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Casts the elements of an <see cref="IAsyncEnumerable{T}"/> to the specified type
    /// </summary>
    /// <typeparam name="TSource">The basic type of elements contained in the sequence</typeparam>
    /// <typeparam name="TResult">The type of elements desired in the result</typeparam>
    /// <param name="source">The sequence of elements to cast</param>
    /// <returns>A sequence of elements that are <typeparamref name="TResult"/></returns>
    public static IAsyncEnumerable<TResult> Cast<TSource, TResult>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return CastInternal<TSource,TResult>(source);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> CastInternal<TSource,TResult>(
      this IAsyncEnumerable<TSource> source)
    {
#nullable disable
      await foreach(object original in source)
      {
        yield return (TResult)original;
      }
#nullable restore
    }
    #endregion
  }
}
