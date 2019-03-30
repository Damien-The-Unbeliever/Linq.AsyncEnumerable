using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Combines corresponding elements from two sequences using a specific function
    /// </summary>
    /// <typeparam name="TFirst">The type of elements in the first sequence</typeparam>
    /// <typeparam name="TSecond">The type of elements in the second sequence</typeparam>
    /// <typeparam name="TResult">The type of elements that the combining function produces</typeparam>
    /// <param name="first">The first sequence</param>
    /// <param name="second">The second sequence</param>
    /// <param name="resultSelector">The combining function, taking an element from the first sequence and an element from the second sequence and producing a result</param>
    /// <returns>The sequence of elements produced from the combining function</returns>
    /// <remarks>If the sequences are of unequal length, this resulting sequence will contain the same number of elements as the shorter of the two</remarks>
    public static IAsyncEnumerable<TResult> Zip<TFirst,TSecond,TResult>(
      this IAsyncEnumerable<TFirst> first,
      IAsyncEnumerable<TSecond> second,
      Func<TFirst,TSecond,TResult> resultSelector)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return ZipInternal(first, second, (a, b) => new ValueTask<TResult>(resultSelector(a, b)));
    }
    /// <summary>
    /// Combines corresponding elements from two sequences using a specific function
    /// </summary>
    /// <typeparam name="TFirst">The type of elements in the first sequence</typeparam>
    /// <typeparam name="TSecond">The type of elements in the second sequence</typeparam>
    /// <typeparam name="TResult">The type of elements that the combining function produces</typeparam>
    /// <param name="first">The first sequence</param>
    /// <param name="second">The second sequence</param>
    /// <param name="resultSelector">The combining function, taking an element from the first sequence and an element from the second sequence and producing a result</param>
    /// <returns>The sequence of elements produced from the combining function</returns>
    /// <remarks>If the sequences are of unequal length, this resulting sequence will contain the same number of elements as the shorter of the two</remarks>
    public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
      this IAsyncEnumerable<TFirst> first,
      IAsyncEnumerable<TSecond> second,
      Func<TFirst, TSecond, ValueTask<TResult>> resultSelector)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return ZipInternal(first, second, resultSelector);
    }
    /// <summary>
    /// Combines corresponding elements from two sequences using a specific function
    /// </summary>
    /// <typeparam name="TFirst">The type of elements in the first sequence</typeparam>
    /// <typeparam name="TSecond">The type of elements in the second sequence</typeparam>
    /// <typeparam name="TResult">The type of elements that the combining function produces</typeparam>
    /// <param name="first">The first sequence</param>
    /// <param name="second">The second sequence</param>
    /// <param name="resultSelector">The combining function, taking an element from the first sequence and an element from the second sequence and producing a result</param>
    /// <returns>The sequence of elements produced from the combining function</returns>
    /// <remarks>If the sequences are of unequal length, this resulting sequence will contain the same number of elements as the shorter of the two</remarks>
    public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
      this IAsyncEnumerable<TFirst> first,
      IAsyncEnumerable<TSecond> second,
      Func<TFirst, TSecond, Task<TResult>> resultSelector)
    {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return ZipInternal(first, second, resultSelector);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> ZipInternal<TFirst, TSecond, TResult>(
      this IAsyncEnumerable<TFirst> first,
      IAsyncEnumerable<TSecond> second,
      Func<TFirst, TSecond, Task<TResult>> resultSelector)
    {
      await using (var iterFirst = first.GetAsyncEnumerator())
      await using (var iterSecond = second.GetAsyncEnumerator())
      {
        while(await iterFirst.MoveNextAsync())
        {
          if (!await iterSecond.MoveNextAsync()) yield break;

          yield return await resultSelector(iterFirst.Current, iterSecond.Current);
        }
      }
    }
    private static async IAsyncEnumerable<TResult> ZipInternal<TFirst, TSecond, TResult>(
      this IAsyncEnumerable<TFirst> first,
      IAsyncEnumerable<TSecond> second,
      Func<TFirst, TSecond, ValueTask<TResult>> resultSelector)
    {
      await using (var iterFirst = first.GetAsyncEnumerator())
      await using (var iterSecond = second.GetAsyncEnumerator())
      {
        while (await iterFirst.MoveNextAsync())
        {
          if (!await iterSecond.MoveNextAsync()) yield break;

          yield return await resultSelector(iterFirst.Current, iterSecond.Current);
        }
      }
    }
    #endregion
  }
}
