using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Returns the last element of the sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The last element of the sequence</returns>
    public static ValueTask<TSource> Last<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return LastOrDefaultInternal(source, QuickFunctions<TSource>.True, true);
    }
    /// <summary>
    /// Returns the last element of the sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The last element of the sequence</returns>
    public static ValueTask<TSource> LastOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return LastOrDefaultInternal(source, QuickFunctions<TSource>.True, false);
    }
    /// <summary>
    /// Returns the last element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The last element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> Last<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LastOrDefaultInternal(source, predicate, true);
    }
    /// <summary>
    /// Returns the last element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The last element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> Last<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LastOrDefaultInternal(source, p => new ValueTask<bool>(predicate(p)), true);
    }
    /// <summary>
    /// Returns the last element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The last element that satfisfied <paramref name="predicate"/></returns>
    public static Task<TSource> Last<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LastOrDefaultInternal(source, predicate, true);
    }
    /// <summary>
    /// Returns the last element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The last element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> LastOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LastOrDefaultInternal(source, predicate, false);
    }
    /// <summary>
    /// Returns the last element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The last element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> LastOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LastOrDefaultInternal(source, p => new ValueTask<bool>(predicate(p)), false);
    }
    /// <summary>
    /// Returns the last element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The last element that satfisfied <paramref name="predicate"/></returns>
    public static Task<TSource> LastOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return LastOrDefaultInternal(source, predicate, false);
    }
    #endregion
    #region Implementation
    private static async ValueTask<TSource> LastOrDefaultInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate,
      bool throwsOnNone)
    {
      TSource found = default!;
      bool foundOne = false;
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          found = item;
          foundOne = true;
        }
      }
      if (foundOne) return found!;
      if (throwsOnNone)
      {
        throw new InvalidOperationException(NoElement);
      }
      else
      {
        return default!;
      }
    }
    private static async Task<TSource> LastOrDefaultInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate,
      bool throwsOnNone)
    {
      TSource found = default!;
      bool foundOne = false;
      await foreach (var item in source)
      {
        if (await predicate(item))
        {
          found = item;
          foundOne = true;
        }
      }
      if (foundOne) return found!;
      if (throwsOnNone)
      {
        throw new InvalidOperationException(NoElement);
      }
      else
      {
        return default!;
      }
    }
    #endregion
  }
}
