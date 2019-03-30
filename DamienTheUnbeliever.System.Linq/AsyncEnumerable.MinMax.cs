using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Locates the lowest value obtained from a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The lowest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TSource"/> will be used to perform comparisons</remarks>
    public static Task<TSource> Min<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return MinInternal(source, QuickFunctions<TSource>.IdentityWrapped, null);
    }
    /// <summary>
    /// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <returns>The lowest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TResult"/> will be used to perform comparisons</remarks>
    public static Task<TResult> Min<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TResult> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MinInternal(source, s => new ValueTask<TResult>(selector(s)), null);
    }
    /// <summary>
    /// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <returns>The lowest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TResult"/> will be used to perform comparisons</remarks>
    public static Task<TResult> Min<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MinInternal(source, selector, null);
    }
    /// <summary>
    /// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <returns>The lowest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TResult"/> will be used to perform comparisons</remarks>
    public static Task<TResult> Min<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TResult>> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MinInternal(source, selector, null);
    }
    /// <summary>
    /// Locates the lowest value obtained from a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The lowest value found in the sequence</returns>
    public static Task<TSource> Min<TSource>(
      this IAsyncEnumerable<TSource> source,
      IComparer<TSource> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return MinInternal(source, QuickFunctions<TSource>.IdentityWrapped, comparer);
    }
    /// <summary>
    /// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The lowest value found in the sequence</returns>
    public static Task<TResult> Min<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TResult> selector,
      IComparer<TResult> comparer
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MinInternal(source, s=>new ValueTask<TResult>(selector(s)), comparer);
    }
    /// <summary>
    /// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The lowest value found in the sequence</returns>
    public static Task<TResult> Min<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector,
      IComparer<TResult> comparer
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MinInternal(source, selector, comparer);
    }
    /// <summary>
    /// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The lowest value found in the sequence</returns>
    public static Task<TResult> Min<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TResult>> selector,
      IComparer<TResult> comparer
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MinInternal(source, selector, comparer);
    }
    /// <summary>
    /// Locates the highest value obtained from a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The highest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TSource"/> will be used to perform comparisons</remarks>
    public static Task<TSource> Max<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return MaxInternal(source, QuickFunctions<TSource>.IdentityWrapped, null);
    }
    /// <summary>
    /// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <returns>The highest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TResult"/> will be used to perform comparisons</remarks>
    public static Task<TResult> Max<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TResult> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MaxInternal(source, s => new ValueTask<TResult>(selector(s)), null);
    }
    /// <summary>
    /// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <returns>The highest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TResult"/> will be used to perform comparisons</remarks>
    public static Task<TResult> Max<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MaxInternal(source, selector, null);
    }
    /// <summary>
    /// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <returns>The highest value found in the sequence</returns>
    /// <remarks>The default comparer for <typeparamref name="TResult"/> will be used to perform comparisons</remarks>
    public static Task<TResult> Max<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TResult>> selector
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MaxInternal(source, selector, null);
    }
    /// <summary>
    /// Locates the highest value obtained from a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The highest value found in the sequence</returns>
    public static Task<TSource> Max<TSource>(
      this IAsyncEnumerable<TSource> source,
      IComparer<TSource> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return MaxInternal(source, QuickFunctions<TSource>.IdentityWrapped, comparer);
    }
    /// <summary>
    /// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The highest value found in the sequence</returns>
    public static Task<TResult> Max<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TResult> selector,
      IComparer<TResult> comparer
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MaxInternal(source, s => new ValueTask<TResult>(selector(s)), comparer);
    }
    /// <summary>
    /// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The highest value found in the sequence</returns>
    public static Task<TResult> Max<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector,
      IComparer<TResult> comparer
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MaxInternal(source, selector, comparer);
    }
    /// <summary>
    /// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TResult">The type of values to compare</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="selector">The selector to transform the results</param>
    /// <param name="comparer">The comparer to use to determine the lowest value</param>
    /// <returns>The highest value found in the sequence</returns>
    public static Task<TResult> Max<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TResult>> selector,
      IComparer<TResult> comparer
    )
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (selector == null) throw new ArgumentNullException(nameof(selector));
      return MaxInternal(source, selector, comparer);
    }
    #endregion
    #region Implementation
    private static async Task<TResult> MinInternal<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TResult>> selector,
      IComparer<TResult>? comparer
    )
    {
      if (comparer == null) comparer = Comparer<TResult>.Default;
      await using(var iterator = source.GetAsyncEnumerator())
      {
        if (!await iterator.MoveNextAsync())
        {
          if (default(TResult)== null) return default!;
          throw new InvalidOperationException(NoElement);
        }
        var result = await selector(iterator.Current);
        while (await iterator.MoveNextAsync())
        {
          var newValue = await selector(iterator.Current);
          if(comparer.Compare(result,newValue)> 0)
          {
            result = newValue;
          }
        }
        return result;
      }
    }
    private static async Task<TResult> MinInternal<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector,
      IComparer<TResult>? comparer
    )
    {
      if (comparer == null) comparer = Comparer<TResult>.Default;
      await using (var iterator = source.GetAsyncEnumerator())
      {
        if (!await iterator.MoveNextAsync())
        {
          if (default(TResult) == null) return default!;
          throw new InvalidOperationException(NoElement);
        }
        var result = await selector(iterator.Current);
        while (await iterator.MoveNextAsync())
        {
          var newValue = await selector(iterator.Current);
          if (comparer.Compare(result, newValue) > 0)
          {
            result = newValue;
          }
        }
        return result;
      }
    }
    private static async Task<TResult> MaxInternal<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TResult>> selector,
      IComparer<TResult>? comparer
    )
    {
      if (comparer == null) comparer = Comparer<TResult>.Default;
      await using (var iterator = source.GetAsyncEnumerator())
      {
        if (!await iterator.MoveNextAsync())
        {
          if (default(TResult) == null) return default!;
          throw new InvalidOperationException(NoElement);
        }
        var result = await selector(iterator.Current);
        while (await iterator.MoveNextAsync())
        {
          var newValue = await selector(iterator.Current);
          if (comparer.Compare(result, newValue) < 0)
          {
            result = newValue;
          }
        }
        return result;
      }
    }
    private static async Task<TResult> MaxInternal<TSource, TResult>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TResult>> selector,
      IComparer<TResult>? comparer
    )
    {
      if (comparer == null) comparer = Comparer<TResult>.Default;
      await using (var iterator = source.GetAsyncEnumerator())
      {
        if (!await iterator.MoveNextAsync())
        {
          if (default(TResult) == null) return default!;
          throw new InvalidOperationException(NoElement);
        }
        var result = await selector(iterator.Current);
        while (await iterator.MoveNextAsync())
        {
          var newValue = await selector(iterator.Current);
          if (comparer.Compare(result, newValue) < 0)
          {
            result = newValue;
          }
        }
        return result;
      }
    }
    #endregion
  }
}
