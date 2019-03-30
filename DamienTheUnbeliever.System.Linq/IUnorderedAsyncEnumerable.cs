using System.Collections.Generic;
using System.Threading;

namespace DamienTheUnbeliever.System.Linq
{
  /// <summary>
  /// An async enumerable that is free to reorder elements based on when each element becomes available
  /// </summary>
  /// <typeparam name="TElement"></typeparam>
  public interface IUnorderedAsyncEnumerable<TElement> : IAsyncEnumerable<TElement>
  {
  }
}
