using DamienTheUnbeliever.System.Linq.Internals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <param name="comparer">The function to use to compare keys</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      IComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, comparer, false);
    }
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <param name="comparer">The function to use to compare keys</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      IComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, comparer, true);
    }
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <param name="comparer">The function to use to compare keys</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      IComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, comparer, false);
    }
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <param name="comparer">The function to use to compare keys</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      IComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, comparer, true);
    }
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, null, false);
    }
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, null, true);
    }
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, null, false);
    }
    /// <summary>
    /// Sort a sequence in ascending order, based on a particular key
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="keySelector">The function to extract a key value from an element</param>
    /// <returns>The sorted sequence</returns>
    public static IOrderedAsyncEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

      return source.CreateOrderedEnumerable(keySelector, null, true);
    }
    #endregion
  }
}
