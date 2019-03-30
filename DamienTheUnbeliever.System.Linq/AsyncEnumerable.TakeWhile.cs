using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Returns elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> until <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> TakeWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return TakeWhileInternal(source, predicate);
    }
    /// <summary>
    /// Returns elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> until <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> TakeWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return TakeWhileInternal(source, p => new ValueTask<bool>(predicate(p)));
    }
    /// <summary>
    /// Returns elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> until <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> TakeWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return TakeWhileInternal(source, predicate);
    }
    /// <summary>
    /// Returns elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> until <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> TakeWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return TakeWhileInternal(source, predicate);
    }
    /// <summary>
    /// Returns elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> until <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> TakeWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return TakeWhileInternal(source, (p, ix) => new ValueTask<bool>(predicate(p, ix)));
    }
    /// <summary>
    /// Returns elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> until <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> TakeWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return TakeWhileInternal(source, predicate);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> TakeWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (!await predicate(item)) yield break;
        yield return item;
      }
    }
    private static async IAsyncEnumerable<TSource> TakeWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (!await predicate(item)) yield break;
        yield return item;
      }
    }
    private static async IAsyncEnumerable<TSource> TakeWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<bool>> predicate)
    {
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        if (!await predicate(item, index)) yield break;
        yield return item;
      }
    }
    private static async IAsyncEnumerable<TSource> TakeWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<bool>> predicate)
    {
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        if (!await predicate(item, index)) yield break;
        yield return item;
      }
    }
    #endregion
  }
}
