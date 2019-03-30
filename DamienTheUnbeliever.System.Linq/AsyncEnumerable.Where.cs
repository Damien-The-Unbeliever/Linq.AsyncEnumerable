using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Filters an <see cref="IAsyncEnumerable{T}"/> based on a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter which items must pass</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing elements that passed the <paramref name="predicate"/></returns>
    public static IAsyncEnumerable<TSource> Where<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return WhereInternal(source, predicate);
    }
    /// <summary>
    /// Filters an <see cref="IAsyncEnumerable{T}"/> based on a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter which items must pass</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing elements that passed the <paramref name="predicate"/></returns>
    public static IAsyncEnumerable<TSource> Where<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return WhereInternal(source, p => new ValueTask<bool>(predicate(p)));
    }
    /// <summary>
    /// Filters an <see cref="IAsyncEnumerable{T}"/> based on a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter which items must pass</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing elements that passed the <paramref name="predicate"/></returns>
    public static IAsyncEnumerable<TSource> Where<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return WhereInternal(source, predicate);
    }
    /// <summary>
    /// Filters an <see cref="IAsyncEnumerable{T}"/> based on a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter which items must pass</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing elements that passed the <paramref name="predicate"/></returns>
    public static IAsyncEnumerable<TSource> Where<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return WhereInternal(source, predicate);
    }
    /// <summary>
    /// Filters an <see cref="IAsyncEnumerable{T}"/> based on a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter which items must pass</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing elements that passed the <paramref name="predicate"/></returns>
    public static IAsyncEnumerable<TSource> Where<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return WhereInternal(source, (p, ix) => new ValueTask<bool>(predicate(p, ix)));
    }
    /// <summary>
    /// Filters an <see cref="IAsyncEnumerable{T}"/> based on a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter which items must pass</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing elements that passed the <paramref name="predicate"/></returns>
    public static IAsyncEnumerable<TSource> Where<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return WhereInternal(source, predicate);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> WhereInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          yield return item;
        }
      }
    }
    private static async IAsyncEnumerable<TSource> WhereInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          yield return item;
        }
      }
    }
    private static async IAsyncEnumerable<TSource> WhereInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<bool>> predicate)
    {
      var index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        if (await predicate(item,index))
        {
          yield return item;
        }
      }
    }
    private static async IAsyncEnumerable<TSource> WhereInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<bool>> predicate)
    {
      var index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        if (await predicate(item,index))
        {
          yield return item;
        }
      }
    }
    #endregion
  }
}
