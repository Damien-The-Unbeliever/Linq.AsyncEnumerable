using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    private class EmptyAsyncEnumerable<TSource> : IAsyncEnumerable<TSource>, IAsyncEnumerator<TSource>
    {
      public TSource Current => throw new NotSupportedException();

      public ValueTask DisposeAsync()
      {
        return new ValueTask();
      }

      public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
      {
        return this;
      }

      public ValueTask<bool> MoveNextAsync()
      {
        return new ValueTask<bool>(false);
      }

      public static IAsyncEnumerable<TSource> Instance { get; } = new EmptyAsyncEnumerable<TSource>();
    }
    /// <summary>
    /// Yields an async enumerable containing no elements
    /// </summary>
    /// <typeparam name="TSource">The type of elements the empty sequence will not contain</typeparam>
    /// <returns>A sequence containing no elements</returns>
    public static IAsyncEnumerable<TSource> Empty<TSource>() => EmptyAsyncEnumerable<TSource>.Instance;
  }
}
