using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  /// <summary>
  /// An async enumerable in which order is strictly defined
  /// </summary>
  /// <typeparam name="TElement">The type of elements returned by the enumerable</typeparam>
  public interface IOrderedAsyncEnumerable<TElement> : IAsyncEnumerable<TElement>
  {
    /// <summary>
    /// Extend an ordered async enumerable by an additional selector to break ties
    /// </summary>
    /// <typeparam name="TKey">The type of keys for the new ordering to work over</typeparam>
    /// <param name="keySelector">The function to extract a key from each element</param>
    /// <param name="comparer">The means by which keys will be compared</param>
    /// <param name="descending">
    /// <para>If true, then each returned element shall be higher or equal (by key) than any subsequent element</para>
    /// <para>If false, then each returned element shall be lower or equal (by key) than any subsequent element</para>
    /// </param>
    /// <returns>The elements applying the appropriate ordering</returns>
    IOrderedAsyncEnumerable<TElement> CreateOrderedEnumerable<TKey>(
      Func<TElement, ValueTask<TKey>> keySelector,
      IComparer<TKey>? comparer,
      bool descending);
    /// <summary>
    /// Extend an ordered async enumerable by an additional selector to break ties
    /// </summary>
    /// <typeparam name="TKey">The type of keys for the new ordering to work over</typeparam>
    /// <param name="keySelector">The function to extract a key from each element</param>
    /// <param name="comparer">The means by which keys will be compared</param>
    /// <param name="descending">
    /// <para>If true, then each returned element shall be higher or equal (by key) than any subsequent element</para>
    /// <para>If false, then each returned element shall be lower or equal (by key) than any subsequent element</para>
    /// </param>
    /// <returns>The elements applying the appropriate ordering</returns>
    IOrderedAsyncEnumerable<TElement> CreateOrderedEnumerable<TKey>(
      Func<TElement, Task<TKey>> keySelector,
      IComparer<TKey>? comparer,
      bool descending);
  }
}
