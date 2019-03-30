using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Determines whether a value is contained in a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="value">The value to locate</param>
    /// <returns>True if the sequence contains the value, otherwise false</returns>
    /// <remarks>The default equality comparer for <typeparamref name="TSource"/> will be used</remarks>
    public static Task<bool> Contains<TSource>(
      this IAsyncEnumerable<TSource> source,
      TSource value)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return ContainsInternal(source, value, null);
    }
    /// <summary>
    /// Determines whether a value is contained in a sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="value">The value to locate</param>
    /// <param name="comparer">The comparer to use for comparing elements in the sequence with <paramref name="value"/></param>
    /// <returns>True if the sequence contains the value, otherwise false</returns>
    /// <remarks>If <paramref name="comparer"/>> is null, the default equality comparer for <typeparamref name="TSource"/> will be used</remarks>
    public static Task<bool> Contains<TSource>(
      this IAsyncEnumerable<TSource> source,
      TSource value,
      IEqualityComparer<TSource> comparer)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return ContainsInternal(source, value, comparer);
    }
    #endregion
    #region Implementation
    private static async Task<bool> ContainsInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      TSource value,
      IEqualityComparer<TSource>? comparer)
    {
      if (comparer == null) comparer = EqualityComparer<TSource>.Default;
      await foreach(var item in source)
      {
        if (comparer.Equals(item, value)) return true;
      }
      return false;
    }
    #endregion
  }
}
