using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Determines whether two sequences are equal
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequences</typeparam>
    /// <param name="first">The first sequence of elements</param>
    /// <param name="second">The second sequence of elements</param>
    /// <returns>True if the sequences are equal, otherwise false</returns>
    /// <remarks>The default equality comparer for <typeparamref name="TSource"/> will be used for comparing elements</remarks>
    public static Task<bool> SequenceEqual<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      return SequenceEqualInternal(first, second, null);
    }
    /// <summary>
    /// Determines whether two sequences are equal using a specific comparer
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequences</typeparam>
    /// <param name="first">The first sequence of elements</param>
    /// <param name="second">The second sequence of elements</param>
    /// <param name="comparer">The comparer to use to determine if two elements are equal</param>
    /// <returns>True if the sequences are equal, otherwise false</returns>
    public static Task<bool> SequenceEqual<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      return SequenceEqualInternal(first, second, comparer);
    }
    #endregion
    #region Implementation
    private static async Task<bool> SequenceEqualInternal<TSource>(
      this IAsyncEnumerable<TSource> first,
      IAsyncEnumerable<TSource> second,
      IEqualityComparer<TSource>? comparer)
    {
      if (comparer == null) comparer = EqualityComparer<TSource>.Default;
      await using (var iterFirst = first.GetAsyncEnumerator())
      await using (var iterSecond = second.GetAsyncEnumerator())
      {
        while (await iterFirst.MoveNextAsync())
        {
          if (!await iterSecond.MoveNextAsync()) return false;

          if (!comparer.Equals(iterFirst.Current, iterSecond.Current)) return false;
        }
        return !await iterSecond.MoveNextAsync();
      }
    }
    #endregion
  }
}
