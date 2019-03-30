using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Correlates the elements of two sequences based on matching keys
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of keys to compare</typeparam>
    /// <typeparam name="TResult">The type of result produced by the join</typeparam>
    /// <param name="outer">The outer sequence of elements</param>
    /// <param name="inner">The inner sequence of elements</param>
    /// <param name="outerKeySelector">The function to extract a key from a <typeparamref name="TOuter"/> element</param>
    /// <param name="innerKeySelector">The function to extract a key from a <typeparamref name="TInner"/> element</param>
    /// <param name="resultSelector">The function to combine a <typeparamref name="TOuter"/> and a <typeparamref name="TInner"/> to produce a <typeparamref name="TResult"/></param>
    /// <returns>The combined results</returns>
    public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, ValueTask<TKey>> outerKeySelector,
      Func<TInner, ValueTask<TKey>> innerKeySelector,
      Func<TOuter, TInner, ValueTask<TResult>>? resultSelector)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return JoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);
    }
    /// <summary>
    /// Correlates the elements of two sequences based on matching keys
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of keys to compare</typeparam>
    /// <typeparam name="TResult">The type of result produced by the join</typeparam>
    /// <param name="outer">The outer sequence of elements</param>
    /// <param name="inner">The inner sequence of elements</param>
    /// <param name="outerKeySelector">The function to extract a key from a <typeparamref name="TOuter"/> element</param>
    /// <param name="innerKeySelector">The function to extract a key from a <typeparamref name="TInner"/> element</param>
    /// <param name="resultSelector">The function to combine a <typeparamref name="TOuter"/> and a <typeparamref name="TInner"/> to produce a <typeparamref name="TResult"/></param>
    /// <returns>The combined results</returns>
    public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, Task<TKey>> outerKeySelector,
      Func<TInner, Task<TKey>> innerKeySelector,
      Func<TOuter, TInner, Task<TResult>>? resultSelector)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return JoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);
    }
    /// <summary>
    /// Correlates the elements of two sequences based on matching keys
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of keys to compare</typeparam>
    /// <typeparam name="TResult">The type of result produced by the join</typeparam>
    /// <param name="outer">The outer sequence of elements</param>
    /// <param name="inner">The inner sequence of elements</param>
    /// <param name="outerKeySelector">The function to extract a key from a <typeparamref name="TOuter"/> element</param>
    /// <param name="innerKeySelector">The function to extract a key from a <typeparamref name="TInner"/> element</param>
    /// <param name="resultSelector">The function to combine a <typeparamref name="TOuter"/> and a <typeparamref name="TInner"/> to produce a <typeparamref name="TResult"/></param>
    /// <param name="comparer">An equality comparer for the keys</param>
    /// <returns>The combined results</returns>
    public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, ValueTask<TKey>> outerKeySelector,
      Func<TInner, ValueTask<TKey>> innerKeySelector,
      Func<TOuter, TInner, ValueTask<TResult>> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return JoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }
    /// <summary>
    /// Correlates the elements of two sequences based on matching keys
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of keys to compare</typeparam>
    /// <typeparam name="TResult">The type of result produced by the join</typeparam>
    /// <param name="outer">The outer sequence of elements</param>
    /// <param name="inner">The inner sequence of elements</param>
    /// <param name="outerKeySelector">The function to extract a key from a <typeparamref name="TOuter"/> element</param>
    /// <param name="innerKeySelector">The function to extract a key from a <typeparamref name="TInner"/> element</param>
    /// <param name="resultSelector">The function to combine a <typeparamref name="TOuter"/> and a <typeparamref name="TInner"/> to produce a <typeparamref name="TResult"/></param>
    /// <param name="comparer">An equality comparer for the keys</param>
    /// <returns>The combined results</returns>
    public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, Task<TKey>> outerKeySelector,
      Func<TInner, Task<TKey>> innerKeySelector,
      Func<TOuter, TInner, Task<TResult>> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
      return JoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> JoinInternal<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, Task<TKey>> outerKeySelector,
      Func<TInner, Task<TKey>> innerKeySelector,
      Func<TOuter, TInner, Task<TResult>> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      var innerLookup = ToLookupInternal(inner, innerKeySelector, QuickFunctions<TInner>.IdentityTasked, comparer);
      await foreach (var outerItem in outer)
      {
        var key = await outerKeySelector(outerItem);
        await foreach (var innerItem in innerLookup.GetItem(key))
        {
          yield return await resultSelector(outerItem, innerItem);
        }
      }
    }
    private static async IAsyncEnumerable<TResult> JoinInternal<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, ValueTask<TKey>> outerKeySelector,
      Func<TInner, ValueTask<TKey>> innerKeySelector,
      Func<TOuter, TInner, ValueTask<TResult>> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      var innerLookup = ToLookupInternal(inner, innerKeySelector, QuickFunctions<TInner>.IdentityWrapped, comparer);
      await foreach (var outerItem in outer)
      {
        var key = await outerKeySelector(outerItem);
        await foreach (var innerItem in innerLookup.GetItem(key))
        {
          yield return await resultSelector(outerItem, innerItem);
        }
      }
    }
    #endregion
  }
}
