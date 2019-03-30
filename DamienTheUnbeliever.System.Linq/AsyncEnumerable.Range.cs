using System.Collections.Generic;
using System.Linq;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Wraps <see cref="Enumerable.Range(int, int)"/>
    /// </summary>
    /// <param name="start">The first number to return</param>
    /// <param name="count">The number of items to return</param>
    /// <returns></returns>
    /// <remarks>There should be no reason to use this method</remarks>
    public static IAsyncEnumerable<int> Range(int start, int count)
    {
      return Enumerable.Range(start, count).AsAsyncEnumerable();
    }
    #endregion
  }
}
