using System.Collections.Generic;
using System.Linq;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Wraps <see cref="Enumerable.Repeat{TResult}(TResult, int)"/>
    /// </summary>
    /// <typeparam name="TElement">The type of elements that are repeated/returned</typeparam>
    /// <param name="element">The element to repeat</param>
    /// <param name="count">The number of times to return the element</param>
    /// <returns></returns>
    /// <remarks>There should be no reason to use this method</remarks>
    public static IAsyncEnumerable<TElement> Repeat<TElement>(TElement element, int count)
    {
      return Enumerable.Repeat(element, count).AsAsyncEnumerable();
    }
    #endregion
  }
}
