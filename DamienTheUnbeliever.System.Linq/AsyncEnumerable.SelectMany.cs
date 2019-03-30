using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="selector">The transformation to obtain each flattened result</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, IAsyncEnumerable<TResult>> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectManyInternal(source, selector, BridgeResultSelector);
    }
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="selector">The transformation that generates the new sequences</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, IAsyncEnumerable<TResult>> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return SelectManyInternal(source, selector, BridgeResultSelector);
    }
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TCollection">The type of elements in the new sequences</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="collectionSelector">The transformation that generates the new sequences</param>
    /// <param name="resultSelector">The transformation to obtain each flattened result</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, Task<TResult>> resultSelector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return SelectManyInternal(source, collectionSelector, resultSelector);
    }
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TCollection">The type of elements in the new sequences</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="collectionSelector">The transformation that generates the new sequences</param>
    /// <param name="resultSelector">The transformation to obtain each flattened result</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, ValueTask<TResult>> resultSelector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return SelectManyInternal(source, collectionSelector, resultSelector);
    }
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TCollection">The type of elements in the new sequences</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="collectionSelector">The transformation that generates the new sequences</param>
    /// <param name="resultSelector">The transformation to obtain each flattened result</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return SelectManyInternal(source, collectionSelector, (src, col) => new ValueTask<TResult>(resultSelector(src, col)));
    }
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TCollection">The type of elements in the new sequences</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="collectionSelector">The transformation that generates the new sequences</param>
    /// <param name="resultSelector">The transformation to obtain each flattened result</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, Task<TResult>> resultSelector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return SelectManyInternal(source, collectionSelector, resultSelector);
    }
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TCollection">The type of elements in the new sequences</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="collectionSelector">The transformation that generates the new sequences</param>
    /// <param name="resultSelector">The transformation to obtain each flattened result</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, ValueTask<TResult>> resultSelector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return SelectManyInternal(source, collectionSelector, resultSelector);
    }
    /// <summary>
    /// Projects a sequence to a new sequence of sequences and then flattens the result
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the original sequence</typeparam>
    /// <typeparam name="TCollection">The type of elements in the new sequences</typeparam>
    /// <typeparam name="TResult">The type of elements in the flattened sequence</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="collectionSelector">The transformation that generates the new sequences</param>
    /// <param name="resultSelector">The transformation to obtain each flattened result</param>
    /// <returns></returns>
    public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return SelectManyInternal(source, collectionSelector, (src, col) => new ValueTask<TResult>(resultSelector(src, col)));
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> SelectManyInternal<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, Task<TResult>> resultSelector
    )
    {
      await foreach(var item in source)
      {
        await foreach(var newItem in collectionSelector(item))
        {
          yield return await resultSelector(item, newItem);
        }
      }
    }
    private static async IAsyncEnumerable<TResult> SelectManyInternal<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, ValueTask<TResult>> resultSelector
    )
    {
      await foreach (var item in source)
      {
        await foreach (var newItem in collectionSelector(item))
        {
          yield return await resultSelector(item, newItem);
        }
      }
    }
    private static async IAsyncEnumerable<TResult> SelectManyInternal<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, Task<TResult>> resultSelector
    )
    {
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        await foreach (var newItem in collectionSelector(item,index))
        {
          yield return await resultSelector(item, newItem);
        }
      }
    }
    private static async IAsyncEnumerable<TResult> SelectManyInternal<TSource, TCollection, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, ValueTask<TResult>> resultSelector
    )
    {
      int index = -1;
      await foreach (var item in source)
      {
        checked
        {
          index++;
        }
        await foreach (var newItem in collectionSelector(item,index))
        {
          yield return await resultSelector(item, newItem);
        }
      }
    }
    private static ValueTask<TResult> BridgeResultSelector<TSource, TResult>(TSource src, TResult res) => new ValueTask<TResult>(res);
    #endregion
  }
}
