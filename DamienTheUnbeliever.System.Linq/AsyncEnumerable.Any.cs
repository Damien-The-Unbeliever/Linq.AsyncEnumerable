using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Determines whether there are any elements in the sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>true if any elements of the sequence satisfy the predicate</returns>
    public static Task<bool> Any<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return AnyInternal(source, QuickFunctions<TSource>.True);
    }
    /// <summary>
    /// Determines whether any elements in a sequence satisfy a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate that any elements should satisfy</param>
    /// <returns>true if any elements of the sequence satisfy the predicate</returns>
    public static Task<bool> Any<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return AnyInternal(source, predicate);
    }
    /// <summary>
    /// Determines whether any elements in a sequence satisfy a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate that any elements should satisfy</param>
    /// <returns>true if any elements of the sequence satisfy the predicate</returns>
    public static Task<bool> Any<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return AnyInternal(source, p=>new ValueTask<bool>(predicate(p)));
    }
    /// <summary>
    /// Determines whether any elements in a sequence satisfy a <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The predicate that any elements should satisfy</param>
    /// <returns>true if any elements of the sequence satisfy the predicate</returns>
    public static Task<bool> Any<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return AnyInternal(source, predicate);
    }
    #endregion
    #region Implementation
    private static async Task<bool> AnyInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (await predicate(item))
          return true;
      }
      return false;
    }
    private static async Task<bool> AnyInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      await foreach (var item in source)
      {
        if (await predicate(item))
          return true;
      }
      return false;
    }
    #endregion
  }
}
