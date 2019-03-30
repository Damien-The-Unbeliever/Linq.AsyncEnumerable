using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region Implementation
    private static async IAsyncEnumerable<TResult> GroupByInternal<TSource, TKey, TElement, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, Task<TElement>> elementSelector,
      Func<TKey, IAsyncEnumerable<TElement>, Task<TResult>> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (comparer == null) comparer = EqualityComparer<TKey>.Default;
      await foreach(var item in ToLookupInternal(source, keySelector, elementSelector, comparer))
      {
        yield return await resultSelector(item.Key, item);
      }
    }
    private static async IAsyncEnumerable<TResult> GroupByInternal<TSource, TKey, TElement, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      Func<TSource, ValueTask<TElement>> elementSelector,
      Func<TKey, IAsyncEnumerable<TElement>, ValueTask<TResult>> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (comparer == null) comparer = EqualityComparer<TKey>.Default;
      await foreach (var item in ToLookupInternal(source, keySelector, elementSelector, comparer))
      {
        yield return await resultSelector(item.Key, item);
      }
    }
    private static IAsyncEnumerable<IAsyncGrouping<TKey,TElement>> GroupByInternal<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, Task<TElement>> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (comparer == null) comparer = EqualityComparer<TKey>.Default;
      return ToLookupInternal(source, keySelector, elementSelector, comparer);
    }
    private static IAsyncEnumerable<IAsyncGrouping<TKey, TElement>> GroupByInternal<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      Func<TSource, ValueTask<TElement>> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (comparer == null) comparer = EqualityComparer<TKey>.Default;
      return ToLookupInternal(source, keySelector, elementSelector, comparer);
    }
    #endregion
  }
}
