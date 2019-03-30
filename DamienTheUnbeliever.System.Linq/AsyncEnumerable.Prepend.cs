using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Creates a sequence from an existing sequence and a new element that should appear before the existing ones
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The existing sequence</param>
    /// <param name="element">The new element</param>
    /// <returns>The sequence containing all elements from the original sequence and the new element</returns>
    public static IAsyncEnumerable<TSource> Prepend<TSource>(
      this IAsyncEnumerable<TSource> source,
      ValueTask<TSource> element)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (element == null) throw new ArgumentNullException(nameof(element));
      return PrependInternal(source, element);
    }
    /// <summary>
    /// Creates a sequence from an existing sequence and a new element that should appear before the existing ones
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The existing sequence</param>
    /// <param name="element">The new element</param>
    /// <returns>The sequence containing all elements from the original sequence and the new element</returns>
    public static IAsyncEnumerable<TSource> Prepend<TSource>(
      this IAsyncEnumerable<TSource> source,
      TSource element)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return PrependInternal(source, new ValueTask<TSource>(element));
    }
    /// <summary>
    /// Creates a sequence from an existing sequence and a new element that should appear before the existing ones
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The existing sequence</param>
    /// <param name="element">The new element</param>
    /// <returns>The sequence containing all elements from the original sequence and the new element</returns>
    public static IAsyncEnumerable<TSource> Prepend<TSource>(
      this IAsyncEnumerable<TSource> source,
      Task<TSource> element)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (element == null) throw new ArgumentNullException(nameof(element));
      return PrependInternal(source, element);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TSource> PrependInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      ValueTask<TSource> element)
    {
      yield return await element;
      await foreach (var item in source)
      {
        yield return item;
      }
    }
    private static async IAsyncEnumerable<TSource> PrependInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Task<TSource> element)
    {
      yield return await element;
      await foreach (var item in source)
      {
        yield return item;
      }
    }
    #endregion
  }
}
