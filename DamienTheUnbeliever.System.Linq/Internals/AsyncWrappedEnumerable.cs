using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal sealed class AsyncWrappedEnumerable<TElement> : IAsyncEnumerable<TElement>
  {
    private readonly IEnumerable<TElement> _wrapped;
    public AsyncWrappedEnumerable(IEnumerable<TElement> wrapped)
    {
      _wrapped = wrapped;
    }
    public IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      return new AsyncWrappedEnumerator(_wrapped.GetEnumerator());
    }

    public sealed class AsyncWrappedEnumerator: IAsyncEnumerator<TElement>
    {
      private readonly IEnumerator<TElement> _wrapped;
      public AsyncWrappedEnumerator(IEnumerator<TElement> wrapped)
      {
        _wrapped = wrapped;
      }

      public TElement Current => _wrapped.Current;

      public ValueTask DisposeAsync()
      {
        _wrapped.Dispose();
        return default;
      }

      public ValueTask<bool> MoveNextAsync()
      {
        return new ValueTask<bool>(_wrapped.MoveNext());
      }
    }
  }
}
