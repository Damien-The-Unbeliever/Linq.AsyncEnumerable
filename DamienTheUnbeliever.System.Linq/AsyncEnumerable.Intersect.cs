﻿using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Performs the set intersect between two sequences
    /// </summary>
    /// <typeparam name="TSource">The type of elements contained in both sequences</typeparam>
    /// <param name="first">The first sequence</param>
    /// <param name="second">The second sequence</param>
    /// <returns>The unique set of elements contained in the set</returns>
    public static IAsyncEnumerable<TSource> Intersect<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      return IntersectInternal(first, second, null);
    }
    /// <summary>
    /// Performs the set intersect between two sequences
    /// </summary>
    /// <typeparam name="TSource">The type of elements contained in both sequences</typeparam>
    /// <param name="first">The first sequence</param>
    /// <param name="second">The second sequence</param>
    /// <param name="comparer">How elements in the sequences should be compared for equality. If null, the default comparer for <typeparamref name="TSource"/> will be used</param>
    /// <returns>The unique set of elements contained in the set</returns>
    public static IAsyncEnumerable<TSource> Intersect<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second,
      IEqualityComparer<TSource>? comparer)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      return IntersectInternal(first, second, comparer);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> IntersectInternal<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second,
      IEqualityComparer<TSource>? comparer)
    {
      var set = new HashSet<TSource>(comparer);
      await foreach(var item in first)
      {
        set.Add(item);
      }
      var secondSet = new HashSet<TSource>(comparer);
      await foreach(var item in second)
      {
        if(set.Contains(item)&&secondSet.Add(item)) yield return item;
      }
    }
    #endregion
  }
}
