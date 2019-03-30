using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class ThrowingAsyncEnumerable<TSource> : IAsyncEnumerable<TSource>
  {
    public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}
