using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  /// <summary>
  /// A dictionary-like collection potentially containing multiple elements per key
  /// </summary>
  /// <typeparam name="TKey">The type of keys by which the lookup is indexed</typeparam>
  /// <typeparam name="TElement">The type of elements contained in the lookup</typeparam>
  public interface IAsyncLookup<TKey, out TElement> : IAsyncEnumerable<IAsyncGrouping<TKey,TElement>>
  {
    /// <summary>
    /// The number of elements contained in the collection
    /// </summary>
    /// <remarks>The count will not be available until the original source has been entirely consumed</remarks>
    Task<int> GetCount();
    /// <summary>
    /// Determines if there are elements for the given key
    /// </summary>
    /// <param name="key">The key to check</param>
    /// <returns>true if the lookup has elements for the key, false otherwise</returns>
    /// <remarks>This method can complete it's task as soon as it is confirmed that there are elements for the key. The entire original source will need to be consumed to return a negative result</remarks>
    Task<bool> ContainsKey(TKey key);
    /// <summary>
    /// Provides the elements contained in the lookup for the given key
    /// </summary>
    /// <param name="key">The key to check</param>
    /// <returns>The sequence of elements contained in this lookup for the key</returns>
    IAsyncEnumerable<TElement> GetItem(TKey key);
  }
}
