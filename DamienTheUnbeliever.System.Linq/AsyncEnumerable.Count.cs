using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Returns the number of elements contained in a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<int> Count<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return CountInternal(source, QuickFunctions<TSource>.True);
    }
    /// <summary>
    /// Returns the number of elements contained in a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<long> LongCount<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return LongCountInternal(source, QuickFunctions<TSource>.True);
    }
    /// <summary>
    /// Returns the number of elements contained in a sequence that match the <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<int> Count<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return CountInternal(source, predicate);
    }
    /// <summary>
    /// Returns the number of elements contained in a sequence that match the <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<int> Count<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return CountInternal(source, b => new ValueTask<bool>(predicate(b)));
    }
    /// <summary>
    /// Returns the number of elements contained in a sequence that match the <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<int> Count<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return CountInternal(source, predicate);
    }
    /// <summary>
    /// Returns the number of elements contained in a sequence that match the <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<long> LongCount<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LongCountInternal(source, predicate);
    }
    /// <summary>
    /// Returns the number of elements contained in a sequence that match the <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<long> LongCount<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LongCountInternal(source, b=>new ValueTask<bool>(predicate(b)));
    }
    /// <summary>
    /// Returns the number of elements contained in a sequence that match the <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to match</param>
    /// <returns>The number of elements in the sequence that matched the predicate</returns>
    public static Task<long> LongCount<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LongCountInternal(source, predicate);
    }
    #endregion
    #region Implementation
    private static async Task<int> CountInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      int count = 0;
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          checked
          {
            count++;
          }
        }
      }
      return count;
    }
    private static async Task<int> CountInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      int count = 0;
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          checked
          {
            count++;
          }
        }
      }
      return count;
    }
    private static async Task<long> LongCountInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      long count = 0;
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          checked
          {
            count++;
          }
        }
      }
      return count;
    }
    private static async Task<long> LongCountInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      long count = 0;
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          checked
          {
            count++;
          }
        }
      }
      return count;
    }
    #endregion
  }
}
