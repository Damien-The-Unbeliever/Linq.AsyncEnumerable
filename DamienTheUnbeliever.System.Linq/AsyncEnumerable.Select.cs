using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Project a sequence of elements to a new type
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the existing sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the projected sequence</typeparam>
    /// <param name="source">The existing sequence of elements</param>
    /// <param name="selector">The <see cref="Func{T, TResult}"/> the transforms the elements in the sequence</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the projected elements</returns>
    public static IAsyncEnumerable<TResult> Select<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TResult>> selector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectInternal(source, selector);
    }
    /// <summary>
    /// Project a sequence of elements to a new type
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the existing sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the projected sequence</typeparam>
    /// <param name="source">The existing sequence of elements</param>
    /// <param name="selector">The <see cref="Func{T, TResult}"/> the transforms the elements in the sequence</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the projected elements</returns>
    public static IAsyncEnumerable<TResult> Select<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectInternal(source,s=> new ValueTask<TResult>(selector(s)));
    }
    /// <summary>
    /// Project a sequence of elements to a new type
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the existing sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the projected sequence</typeparam>
    /// <param name="source">The existing sequence of elements</param>
    /// <param name="selector">The <see cref="Func{T, TResult}"/> the transforms the elements in the sequence</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the projected elements</returns>
    public static IAsyncEnumerable<TResult> Select<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectInternal(source, selector);
    }
    /// <summary>
    /// Project a sequence of elements to a new type
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the existing sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the projected sequence</typeparam>
    /// <param name="source">The existing sequence of elements</param>
    /// <param name="selector">The <see cref="Func{T, TResult}"/> the transforms the elements in the sequence</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the projected elements</returns>
    public static IAsyncEnumerable<TResult> Select<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<TResult>> selector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectInternal(source, selector);
    }
    /// <summary>
    /// Project a sequence of elements to a new type
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the existing sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the projected sequence</typeparam>
    /// <param name="source">The existing sequence of elements</param>
    /// <param name="selector">The <see cref="Func{T, TResult}"/> the transforms the elements in the sequence</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the projected elements</returns>
    public static IAsyncEnumerable<TResult> Select<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, TResult> selector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectInternal(source, (s,ix) => new ValueTask<TResult>(selector(s,ix)));
    }
    /// <summary>
    /// Project a sequence of elements to a new type
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the existing sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the projected sequence</typeparam>
    /// <param name="source">The existing sequence of elements</param>
    /// <param name="selector">The <see cref="Func{T, TResult}"/> the transforms the elements in the sequence</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> containing the projected elements</returns>
    public static IAsyncEnumerable<TResult> Select<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<TResult>> selector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectInternal(source, selector);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> SelectInternal<TSource,TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource,ValueTask<TResult>> selector)
    {
      await foreach(var item in source)
      {
        yield return await selector(item);
      }
    }
    private static async IAsyncEnumerable<TResult> SelectInternal<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector)
    {
      await foreach (var item in source)
      {
        yield return await selector(item);
      }
    }
    private static async IAsyncEnumerable<TResult> SelectInternal<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, ValueTask<TResult>> selector)
    {
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        yield return await selector(item,index);
      }
    }
    private static async IAsyncEnumerable<TResult> SelectInternal<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, Task<TResult>> selector)
    {
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        yield return await selector(item, index);
      }
    }
    #endregion
  }
}
