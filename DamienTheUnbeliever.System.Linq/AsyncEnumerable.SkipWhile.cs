using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Bypasses elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> after <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> SkipWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SkipWhileInternal(source, predicate);
    }
    /// <summary>
    /// Bypasses elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> after <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> SkipWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SkipWhileInternal(source, p => new ValueTask<bool>(predicate(p)));
    }
    /// <summary>
    /// Bypasses elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> after <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> SkipWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SkipWhileInternal(source, predicate);
    }
    /// <summary>
    /// Bypasses elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> after <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> SkipWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SkipWhileInternal(source, predicate);
    }
    /// <summary>
    /// Bypasses elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> after <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> SkipWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SkipWhileInternal(source, (p,ix) => new ValueTask<bool>(predicate(p,ix)));
    }
    /// <summary>
    /// Bypasses elements in the original sequence until <paramref name="predicate"/> returns false
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate to test</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing all of the elements contained in <paramref name="source"/> after <paramref name="predicate"/> returned false</returns>
    public static IAsyncEnumerable<TSource> SkipWhile<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SkipWhileInternal(source, predicate);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> SkipWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      bool yield = false;
      await foreach (var item in source)
      {
        if (!yield && !await predicate(item))
        {
          yield = true;
        }
        if (yield) yield return item;
      }
    }
    private static async IAsyncEnumerable<TSource> SkipWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      bool yield = false;
      await foreach (var item in source)
      {
        if (!yield && !await predicate(item))
        {
          yield = true;
        }
        if (yield) yield return item;
      }
    }
    private static async IAsyncEnumerable<TSource> SkipWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<bool>> predicate)
    {
      bool yield = false;
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        if (!yield && !await predicate(item,index))
        {
          yield = true;
        }
        if (yield) yield return item;
      }
    }
    private static async IAsyncEnumerable<TSource> SkipWhileInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<bool>> predicate)
    {
      bool yield = false;
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        if (!yield && !await predicate(item,index))
        {
          yield = true;
        }
        if (yield) yield return item;
      }
    }
    #endregion
  }
}
