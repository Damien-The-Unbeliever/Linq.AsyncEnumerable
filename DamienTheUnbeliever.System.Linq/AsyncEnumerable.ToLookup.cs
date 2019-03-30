using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      return ToLookupInternal(source, s => new ValueTask<TKey>(keySelector(s)), QuickFunctions<TSource>.IdentityWrapped, comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      return ToLookupInternal(source, s => new ValueTask<TKey>(keySelector(s)), QuickFunctions<TSource>.IdentityWrapped, null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, s => new ValueTask<TKey>(keySelector(s)), s => new ValueTask<TElement>(elementSelector(s)), comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, s => new ValueTask<TKey>(keySelector(s)), s => new ValueTask<TElement>(elementSelector(s)), null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      return ToLookupInternal(source, s => new ValueTask<TKey>(keySelector(s)), QuickFunctions<TSource>.IdentityWrapped, comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      return ToLookupInternal(source, keySelector, QuickFunctions<TSource>.IdentityTasked, null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, Task<TElement>> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, elementSelector, comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, Task<TElement>> elementSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, elementSelector, null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, Task<TElement>> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, k=>Task.FromResult(keySelector(k)), elementSelector, comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, Task<TElement>> elementSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, k => Task.FromResult(keySelector(k)), elementSelector, null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, k => Task.FromResult(elementSelector(k)), comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, k => Task.FromResult(elementSelector(k)), null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      return ToLookupInternal(source, keySelector, QuickFunctions<TSource>.IdentityWrapped, comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      return ToLookupInternal(source, keySelector, QuickFunctions<TSource>.IdentityWrapped, null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      Func<TSource, ValueTask<TElement>> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, elementSelector, comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      Func<TSource, ValueTask<TElement>> elementSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, elementSelector, null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, ValueTask<TElement>> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, s => new ValueTask<TKey>(keySelector(s)), elementSelector, comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, ValueTask<TElement>> elementSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, s => new ValueTask<TKey>(keySelector(s)), elementSelector, null);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <param name="comparer">A comparer to determine if key values are equal</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, s => new ValueTask<TElement>(elementSelector(s)), comparer);
    }
    /// <summary>
    /// Constructs an <see cref="IAsyncLookup{TKey, TElement}"/> from a sequence based on a <paramref name="keySelector"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <typeparam name="TKey">The type of the key to extract from each element</typeparam>
    /// <typeparam name="TElement">The type of element which will appear in the lookup</typeparam>
    /// <param name="source">The original sequence</param>
    /// <param name="keySelector">The function that extracts the key from the element</param>
    /// <param name="elementSelector">A function to transform the original element</param>
    /// <returns>The lookup</returns>
    public static IAsyncLookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
      return ToLookupInternal(source, keySelector, s => new ValueTask<TElement>(elementSelector(s)), null);
    }
    #endregion
    #region Implementation
    private static IAsyncLookup<TKey, TElement> ToLookupInternal<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<TKey>> keySelector,
      Func<TSource, ValueTask<TElement>> elementSelector,
      IEqualityComparer<TKey>? comparer)
    {
      return new Internals.Value.AsyncLookup<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer ?? EqualityComparer<TKey>.Default);
    }
    private static IAsyncLookup<TKey, TElement> ToLookupInternal<TSource, TKey, TElement>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, Task<TElement>> elementSelector,
      IEqualityComparer<TKey>? comparer)
    {
      return new Internals.Tasks.AsyncLookup<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer ?? EqualityComparer<TKey>.Default);
    }
    #endregion
  }
}
