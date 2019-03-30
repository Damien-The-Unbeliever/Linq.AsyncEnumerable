using DamienTheUnbeliever.System.Linq.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> into an <see cref="IAsyncEnumerable{T}"/> via the introduction of tasks for individual elements
    /// </summary>
    /// <typeparam name="TResult">The type of elements in the returned <see cref="IAsyncEnumerable{T}"/></typeparam>
    /// <param name="source">The source elements</param>
    /// <returns>The new <see cref="IAsyncEnumerable{T}"/></returns>
    /// <remarks>
    /// <para>The original sequence is consumed eagerly before this method returns</para>
    /// <para>This method is intended for internal use only</para>
    /// </remarks>
    public static IAsyncEnumerable<TResult> AsAsyncEnumerable<TResult>(
      this IEnumerable<TResult> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));

      return new AsyncWrappedEnumerable<TResult>(source);
    }
    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> into an <see cref="IAsyncEnumerable{T}"/> via the introduction of tasks for individual elements
    /// </summary>
    /// <typeparam name="TResult">The type of elements in the returned <see cref="IAsyncEnumerable{T}"/></typeparam>
    /// <param name="source">The source elements</param>
    /// <returns>The new <see cref="IAsyncEnumerable{T}"/></returns>
    /// <remarks>
    /// <para>The original sequence is consumed eagerly before this method returns</para>
    /// <para>Items are returned in the same order as the original sequence</para>
    /// </remarks>
    public static IAsyncEnumerable<TResult> AsAsyncEnumerable<TResult>(
      this IEnumerable<Task<TResult>> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return AsAsyncEnumerableInternal(source, QuickFunctions<Task<TResult>>.Identity);
    }
    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> into an <see cref="IAsyncEnumerable{T}"/> via the introduction of tasks for individual elements
    /// </summary>
    /// <typeparam name="TResult">The type of elements in the returned <see cref="IAsyncEnumerable{T}"/></typeparam>
    /// <param name="source">The source elements</param>
    /// <returns>The new <see cref="IAsyncEnumerable{T}"/></returns>
    /// <remarks>The original sequence is consumed eagerly before this method returns</remarks>
    public static IUnorderedAsyncEnumerable<TResult> AsUnorderedAsyncEnumerable<TResult>(
    this IEnumerable<Task<TResult>> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return AsUnorderedAsyncEnumerableInternal(source, QuickFunctions<Task<TResult>>.Identity);
    }
    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> into an <see cref="IAsyncEnumerable{T}"/> via the introduction of tasks for individual elements
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <typeparam name="TResult">The type of elements in the returned <see cref="IAsyncEnumerable{T}"/></typeparam>
    /// <param name="source">The source elements</param>
    /// <param name="resultSelector">A method that will create a <see cref="Task{TResult}"/> for each element in the <paramref name="source"/></param>
    /// <returns>The new <see cref="IAsyncEnumerable{T}"/></returns>
    /// <remarks>
    /// <para>The original sequence is consumed eagerly and <paramref name="resultSelector"/> called on each element before this method returns</para>
    /// <para>Items are returned in the same order as the original sequence</para>
    /// </remarks>
    public static IAsyncEnumerable<TResult> AsAsyncEnumerable<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, Task<TResult>> resultSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return AsAsyncEnumerableInternal(source, resultSelector);
    }
    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> into an <see cref="IAsyncEnumerable{T}"/> via the introduction of tasks for individual elements
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <typeparam name="TResult">The type of elements in the returned <see cref="IAsyncEnumerable{T}"/></typeparam>
    /// <param name="source">The source elements</param>
    /// <param name="resultSelector">A method that will create a <see cref="Task{TResult}"/> for each element in the <paramref name="source"/></param>
    /// <returns>The new <see cref="IAsyncEnumerable{T}"/></returns>
    /// <remarks>The original sequence is consumed eagerly and <paramref name="resultSelector"/> called on each element before this method returns</remarks>
    public static IUnorderedAsyncEnumerable<TResult> AsUnorderedAsyncEnumerable<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, Task<TResult>> resultSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return AsUnorderedAsyncEnumerableInternal(source, resultSelector);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> AsAsyncEnumerableInternal<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, Task<TResult>> resultSelector)
    {
      var tasks = source.Select(resultSelector).ToList();
      foreach (var item in tasks)
      {
        yield return await item.ConfigureAwait(false);
      }

    }
    private static async IAsyncEnumerable<TResult> AsUnorderedAsyncEnumerableInternal2<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, Task<TResult>> resultSelector)
    {
      var tasks = source.Select(resultSelector).ToList();
      while (tasks.Count > 0)
      {
        var next = await Task.WhenAny(tasks);
        tasks.Remove(next);
        yield return next.Result;
      }
    }
    private static IUnorderedAsyncEnumerable<TResult> AsUnorderedAsyncEnumerableInternal<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, Task<TResult>> resultSelector)
    {
      return new Shim<TResult>(AsUnorderedAsyncEnumerableInternal2(source, resultSelector));
    }

    private sealed class Shim<TResult> : IUnorderedAsyncEnumerable<TResult>
    {
      private readonly IAsyncEnumerable<TResult> _inner;
      public Shim(IAsyncEnumerable<TResult> inner)
      {
        _inner = inner;
      }

      public IAsyncEnumerator<TResult> GetAsyncEnumerator(CancellationToken cancellationToken = default)
      {
        return _inner.GetAsyncEnumerator();
      }
    }
    #endregion
  }
}
