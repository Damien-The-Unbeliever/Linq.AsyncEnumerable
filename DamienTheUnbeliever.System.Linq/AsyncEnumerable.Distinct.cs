using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Finds the distinct elements in a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements contained in the sequences</typeparam>
    /// <param name="source">The sequence</param>
    /// <returns>The unique set of elements contained in the set</returns>
    public static IAsyncEnumerable<TSource> Distinct<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return DistinctInternal(source, null);
    }
    /// <summary>
    /// Finds the distinct elements in a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements contained in the sequences</typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="comparer">How elements in the sequence should be compared for equality. If null, the default comparer for <typeparamref name="TSource"/> will be used</param>
    /// <returns>The unique set of elements contained in the set</returns>
    public static IAsyncEnumerable<TSource> Distinct<TSource>(
      this IAsyncEnumerable<TSource> source,
      IEqualityComparer<TSource>? comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return DistinctInternal(source, comparer);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> DistinctInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      IEqualityComparer<TSource>? comparer)
    {
      var set = new HashSet<TSource>(comparer);
      await foreach(var item in source)
      {
        if (set.Add(item)) yield return item;
      }
    }
    #endregion
  }
}
