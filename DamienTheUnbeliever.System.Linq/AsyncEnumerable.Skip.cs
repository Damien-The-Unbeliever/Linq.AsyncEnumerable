using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Returns a sequence omitting the first <paramref name="count"/> elements of the original sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="count">The number of elements to omit</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> except for the first <paramref name="count"/></returns>
    public static IAsyncEnumerable<TSource> Skip<TSource>(
      this IAsyncEnumerable<TSource> source,
      int count)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return SkipInternal(source, count);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> SkipInternal<TSource>(
    this IAsyncEnumerable<TSource> source,
    int count)
    {
      await using (var iterator = source.GetAsyncEnumerator())
      {
        for (int seen = 0; seen < count; seen++)
        {
          if (!await iterator.MoveNextAsync()) yield break;
        }
        while (await iterator.MoveNextAsync())
        {
          yield return iterator.Current;
        }
      }
    }
    #endregion
  }
}
