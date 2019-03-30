using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq
{
  /// <summary>
  /// A group of elements all related by the same <typeparamref name="TKey"/> value
  /// </summary>
  /// <typeparam name="TKey">The type of key for the grouping</typeparam>
  /// <typeparam name="TElement">The elements that share the same key</typeparam>
  public interface IAsyncGrouping<out TKey, out TElement>: IAsyncEnumerable<TElement>
  {
    /// <summary>
    /// The key that all elements in the group share
    /// </summary>
    TKey Key { get; }
  }
}
