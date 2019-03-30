using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Returns the single element of the sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The single element of the sequence</returns>
    public static ValueTask<TSource> Single<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return SingleOrDefaultInternal(source, QuickFunctions<TSource>.True, true);
    }
    /// <summary>
    /// Returns the single element of the sequence
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <returns>The single element of the sequence</returns>
    public static ValueTask<TSource> SingleOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return SingleOrDefaultInternal(source, QuickFunctions<TSource>.True, false);
    }
    /// <summary>
    /// Returns the single element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> Single<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SingleOrDefaultInternal(source, predicate, true);
    }
    /// <summary>
    /// Returns the single element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> Single<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SingleOrDefaultInternal(source, p => new ValueTask<bool>(predicate(p)), true);
    }
    /// <summary>
    /// Returns the single element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The element that satfisfied <paramref name="predicate"/></returns>
    public static Task<TSource> Single<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SingleOrDefaultInternal(source, predicate, true);
    }
    /// <summary>
    /// Returns the single element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> SingleOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, ValueTask<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SingleOrDefaultInternal(source, predicate, false);
    }
    /// <summary>
    /// Returns the single element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The element that satfisfied <paramref name="predicate"/></returns>
    public static ValueTask<TSource> SingleOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SingleOrDefaultInternal(source, p => new ValueTask<bool>(predicate(p)), false);
    }
    /// <summary>
    /// Returns the single element of the sequence that satisfies <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="predicate">The filter for finding a correct element</param>
    /// <returns>The element that satfisfied <paramref name="predicate"/></returns>
    public static Task<TSource> SingleOrDefault<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, Task<bool>> predicate)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));
      return SingleOrDefaultInternal(source, predicate, false);
    }
    #endregion
    #region Implementation
    private static async ValueTask<TSource> SingleOrDefaultInternal<TSource>(
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
          if (foundOne)
          {
            throw new InvalidOperationException(MultipleElements);
          }
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
    private static async Task<TSource> SingleOrDefaultInternal<TSource>(
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
          if (foundOne)
          {
            throw new InvalidOperationException(MultipleElements);
          }
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
