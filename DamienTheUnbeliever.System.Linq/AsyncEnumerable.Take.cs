using System;
using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Returns a sequence only including the first <paramref name="count"/> elements of the original sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="count">The number of elements to keep</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the first <paramref name="count"/> elements from <paramref name="source"/></returns>
    public static IAsyncEnumerable<TSource> Take<TSource>(
      this IAsyncEnumerable<TSource> source,
      int count)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return TakeInternal(source, count);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> TakeInternal<TSource>(
    this IAsyncEnumerable<TSource> source,
    int count)
    {
      await using (var iterator = source.GetAsyncEnumerator())
      {
        for (int seen = 0; seen < count; seen++)
        {
          if (!await iterator.MoveNextAsync()) yield break;
          yield return iterator.Current;
        }
      }
    }
    #endregion
  }
}
