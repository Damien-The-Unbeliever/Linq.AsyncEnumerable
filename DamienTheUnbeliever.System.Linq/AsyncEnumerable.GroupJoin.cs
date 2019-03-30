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
    /// Joins two sequences based on a key and groups the results 
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of key used for matching elements</typeparam>
    /// <typeparam name="TResult">The type of elements in the returned sequence</typeparam>
    /// <param name="outer">The outer sequence</param>
    /// <param name="inner">The inner sequence</param>
    /// <param name="outerKeySelector">The function to extract a key from an outer element</param>
    /// <param name="innerKeySelector">The function to extract a key from an inner element</param>
    /// <param name="resultSelector">The function to combine an outer item and a group of inner items</param>
    /// <returns>A new sequence of result element</returns>
    public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, TResult> resultSelector)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

      return GroupJoinInternal(outer, inner,QuickFunctions.WrapValueTask(outerKeySelector), QuickFunctions.WrapValueTask(innerKeySelector), QuickFunctions.WrapValueTask(resultSelector), null);
    }
    /// <summary>
    /// Joins two sequences based on a key and groups the results 
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of key used for matching elements</typeparam>
    /// <typeparam name="TResult">The type of elements in the returned sequence</typeparam>
    /// <param name="outer">The outer sequence</param>
    /// <param name="inner">The inner sequence</param>
    /// <param name="outerKeySelector">The function to extract a key from an outer element</param>
    /// <param name="innerKeySelector">The function to extract a key from an inner element</param>
    /// <param name="resultSelector">The function to combine an outer item and a group of inner items</param>
    /// <returns>A new sequence of result element</returns>
    public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, ValueTask<TKey>> outerKeySelector,
      Func<TInner, ValueTask<TKey>> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, ValueTask<TResult>> resultSelector)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

      return GroupJoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);
    }
    /// <summary>
    /// Joins two sequences based on a key and groups the results 
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of key used for matching elements</typeparam>
    /// <typeparam name="TResult">The type of elements in the returned sequence</typeparam>
    /// <param name="outer">The outer sequence</param>
    /// <param name="inner">The inner sequence</param>
    /// <param name="outerKeySelector">The function to extract a key from an outer element</param>
    /// <param name="innerKeySelector">The function to extract a key from an inner element</param>
    /// <param name="resultSelector">The function to combine an outer item and a group of inner items</param>
    /// <returns>A new sequence of result element</returns>
    public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, Task<TKey>> outerKeySelector,
      Func<TInner, Task<TKey>> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, Task<TResult>> resultSelector)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

      return GroupJoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);
    }
    /// <summary>
    /// Joins two sequences based on a key and groups the results 
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of key used for matching elements</typeparam>
    /// <typeparam name="TResult">The type of elements in the returned sequence</typeparam>
    /// <param name="outer">The outer sequence</param>
    /// <param name="inner">The inner sequence</param>
    /// <param name="outerKeySelector">The function to extract a key from an outer element</param>
    /// <param name="innerKeySelector">The function to extract a key from an inner element</param>
    /// <param name="resultSelector">The function to combine an outer item and a group of inner items</param>
    /// <param name="comparer">The means to determine if two keys are equal</param>
    /// <returns>A new sequence of result element</returns>
    public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

      return GroupJoinInternal(outer, inner, QuickFunctions.WrapValueTask(outerKeySelector), QuickFunctions.WrapValueTask(innerKeySelector), QuickFunctions.WrapValueTask(resultSelector), comparer);
    }
    /// <summary>
    /// Joins two sequences based on a key and groups the results 
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of key used for matching elements</typeparam>
    /// <typeparam name="TResult">The type of elements in the returned sequence</typeparam>
    /// <param name="outer">The outer sequence</param>
    /// <param name="inner">The inner sequence</param>
    /// <param name="outerKeySelector">The function to extract a key from an outer element</param>
    /// <param name="innerKeySelector">The function to extract a key from an inner element</param>
    /// <param name="resultSelector">The function to combine an outer item and a group of inner items</param>
    /// <param name="comparer">The means to determine if two keys are equal</param>
    /// <returns>A new sequence of result element</returns>
    public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, ValueTask<TKey>> outerKeySelector,
      Func<TInner, ValueTask<TKey>> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, ValueTask<TResult>> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

      return GroupJoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }
    /// <summary>
    /// Joins two sequences based on a key and groups the results 
    /// </summary>
    /// <typeparam name="TOuter">The type of elements in the outer sequence</typeparam>
    /// <typeparam name="TInner">The type of elements in the inner sequence</typeparam>
    /// <typeparam name="TKey">The type of key used for matching elements</typeparam>
    /// <typeparam name="TResult">The type of elements in the returned sequence</typeparam>
    /// <param name="outer">The outer sequence</param>
    /// <param name="inner">The inner sequence</param>
    /// <param name="outerKeySelector">The function to extract a key from an outer element</param>
    /// <param name="innerKeySelector">The function to extract a key from an inner element</param>
    /// <param name="resultSelector">The function to combine an outer item and a group of inner items</param>
    /// <param name="comparer">The means to determine if two keys are equal</param>
    /// <returns>A new sequence of result element</returns>
    public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, Task<TKey>> outerKeySelector,
      Func<TInner, Task<TKey>> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, Task<TResult>> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (outer == null) throw new ArgumentNullException(nameof(outer));
      if (inner == null) throw new ArgumentNullException(nameof(inner));
      if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
      if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
      if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

      return GroupJoinInternal(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }
    #endregion
    #region Implementation
    private static async IAsyncEnumerable<TResult> GroupJoinInternal<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, Task<TKey>> outerKeySelector,
      Func<TInner, Task<TKey>> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, Task<TResult>> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      var innerLookup = ToLookupInternal(inner, innerKeySelector, QuickFunctions<TInner>.IdentityTasked, comparer);
      await foreach(var outerItem in outer)
      {
        var innerItems = innerLookup.GetItem(await outerKeySelector(outerItem));
        yield return await resultSelector(outerItem, innerItems);
      }
    }
    private static async IAsyncEnumerable<TResult> GroupJoinInternal<TOuter, TInner, TKey, TResult>(
      this IAsyncEnumerable<TOuter> outer,
      IAsyncEnumerable<TInner> inner,
      Func<TOuter, ValueTask<TKey>> outerKeySelector,
      Func<TInner, ValueTask<TKey>> innerKeySelector,
      Func<TOuter, IAsyncEnumerable<TInner>, ValueTask<TResult>> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      var innerLookup = ToLookupInternal(inner, innerKeySelector, QuickFunctions<TInner>.IdentityWrapped, comparer);
      await foreach (var outerItem in outer)
      {
        var innerItems = innerLookup.GetItem(await outerKeySelector(outerItem));
        yield return await resultSelector(outerItem, innerItems);
      }
    }
    #endregion
  }
}
