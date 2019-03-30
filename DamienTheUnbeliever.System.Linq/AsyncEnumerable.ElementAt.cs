using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Returns the element at the specified index in the sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="index">The position within the sequence to locate</param>
    /// <returns>The element at the specified index</returns>
    /// <exception cref="ArgumentOutOfRangeException">If <paramref name="index"/> is less than 0 or would require a longer sequence than <paramref name="source"/></exception>
    public static Task<TSource> ElementAt<TSource>(
      this IAsyncEnumerable<TSource> source,
      int index)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
      return ElementAtInternal(source, index, true);
    }
    /// <summary>
    /// Returns the element at the specified index in the sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="index">The position within the sequence to locate</param>
    /// <returns>The element at the specified index if the index is within bounds. default<typeparamref name="TSource"/> otherwise</returns>
    public static Task<TSource> ElementAtOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source,
      int index)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return ElementAtInternal(source, index, false);
    }
    #endregion
    #region Implementation
    private static async Task<TSource> ElementAtInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      int index,
      bool throwIfTooLarge)
    {
      if (index < 0) return default!;
      long count = -1;
      await foreach(var item in source)
      {
        checked {
          count++;
        }
        if (index == count)
        {
          return item;
        }
      }
      if (throwIfTooLarge)
      {
        throw new ArgumentOutOfRangeException(nameof(index));
      }
      else
      {
        return default!;
      }
    }
    #endregion
  }
}
