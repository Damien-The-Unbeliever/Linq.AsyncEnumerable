using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Determines whether all elements in a sequence satisfy a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate that all elements should satisfy</param>
    /// <returns>true if all elements of the sequence satisfy the predicate</returns>
    /// <remarks>Note that it is vacuously true that an empty sequence satisfies the condition</remarks>
    public static Task<bool> All<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return AllInternal(source, predicate);
    }
    /// <summary>
    /// Determines whether all elements in a sequence satisfy a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate that all elements should satisfy</param>
    /// <returns>true if all elements of the sequence satisfy the predicate</returns>
    /// <remarks>Note that it is vacuously true that an empty sequence satisfies the condition</remarks>
    public static Task<bool> All<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return AllInternal(source, QuickFunctions.WrapValueTask(predicate));
    }
    /// <summary>
    /// Determines whether all elements in a sequence satisfy a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate that all elements should satisfy</param>
    /// <returns>true if all elements of the sequence satisfy the predicate</returns>
    /// <remarks>Note that it is vacuously true that an empty sequence satisfies the condition</remarks>
    public static Task<bool> All<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return AllInternal(source, predicate);
    }
    #endregion
    #region Implementation
    private static async Task<bool> AllInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (!await predicate(item))
          return false;
      }
      return true;
    }
    private static async Task<bool> AllInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (!await predicate(item))
          return false;
      }
      return true;
    }
    #endregion
  }
}
