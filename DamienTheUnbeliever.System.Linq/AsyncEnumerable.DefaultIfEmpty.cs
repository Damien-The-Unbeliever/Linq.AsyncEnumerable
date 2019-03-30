using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Ensures we have at least one element in a sequence by supplying a default
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The possible empty sequence of elements</param>
    /// <returns>A non-empty sequence</returns>
    public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return DefaultIfEmptyInternal(source, default!);
    }
    /// <summary>
    /// Ensures we have at least one element in a sequence by supplying a default
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The possible empty sequence of elements</param>
    /// <param name="defaultValue">The element to return if the sequence is empty</param>
    /// <returns>A non-empty sequence</returns>
    public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(
      this IAsyncEnumerable<TSource> source,
      TSource defaultValue)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return DefaultIfEmptyInternal(source,defaultValue);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> DefaultIfEmptyInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      TSource defaultValue)
    {
      bool yieldedOne = false;
      await foreach (var item in source)
      {
        yield return item;
        yieldedOne = true;
      }
      if (!yieldedOne)
      {
        yield return defaultValue;
      }
    }
    #endregion
  }
}
