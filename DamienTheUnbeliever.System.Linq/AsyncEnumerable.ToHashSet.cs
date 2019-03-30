using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Creates a <see cref="HashSet{T}"/> from an <see cref="IAsyncEnumerable{T}"/> using the default comparer for <typeparamref name="TSource"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">An <see cref="IAsyncEnumerable{T}"/> to create the <see cref="HashSet{T}"/> from</param>
    /// <returns>A <see cref="HashSet{T}"/> that contains values of type <typeparamref name="TSource"/> selected from the input sequence.</returns>
    public static Task<HashSet<TSource>> ToHashSet<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return ToHashSetInternal(source, null);
    }
    /// <summary>
    /// Creates a <see cref="HashSet{T}"/> from an <see cref="IAsyncEnumerable{T}"/> using the <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">An <see cref="IAsyncEnumerable{T}"/> to create the <see cref="HashSet{T}"/> from</param>
    /// <param name="comparer">An <see cref="EqualityComparer{T}"/> to compare the elements. If null, the default comparer will be used</param>
    /// <returns>A <see cref="HashSet{T}"/> that contains values of type <typeparamref name="TSource"/> selected from the input sequence.</returns>
    public static Task<HashSet<TSource>> ToHashSet<TSource>(
      this IAsyncEnumerable<TSource> source,
      IEqualityComparer<TSource>? comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return ToHashSetInternal(source, comparer);
    }
    #endregion
    #region Implementation
    private static async Task<HashSet<TSource>> ToHashSetInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      IEqualityComparer<TSource>? comparer)
    {
      var set = new HashSet<TSource>(comparer);
      await foreach(var item in source)
      {
        set.Add(item);
      }
      return set;
    }
    #endregion
  }
}
