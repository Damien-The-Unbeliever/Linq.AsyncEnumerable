using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Creates a sequence by concatenating two other sequence
    /// </summary>
    /// <typeparam name="TSource">The type of items contained in both sequences</typeparam>
    /// <param name="first">The sequence of items that should appear first in the combined sequence</param>
    /// <param name="second">The sequence of items that should appear in the combined sequence once <paramref name="first"/> is exhausted</param>
    /// <returns>The combined sequence</returns>
    public static IAsyncEnumerable<TSource> Concat<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      return ConcatInternal(first, second);
    }

    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> ConcatInternal<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second)
    {
      await foreach(var item in first)
      {
        yield return item;
      }
      await foreach(var item in second)
      {
        yield return item;
      }
    }
    #endregion
  }
}
