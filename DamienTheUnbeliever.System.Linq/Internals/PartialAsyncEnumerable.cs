using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal abstract class PartialAsyncEnumerable<TCompositeElement, TPartialElement> : IAsyncEnumerable<TPartialElement>
  {
    public abstract IAsyncEnumerator<TPartialElement> GetAsyncEnumerator(CancellationToken cancellationToken = default);
  }

  internal abstract class PartialAsyncEnumerator<TCompositeElement, TPartialElement> : IAsyncEnumerator<TPartialElement>
  {
    protected readonly CompositeAsyncEnumerator<TCompositeElement, TPartialElement> _owner;

    public bool IsDisposed { get; private set; } = false;

    protected PartialAsyncEnumerator(CompositeAsyncEnumerator<TCompositeElement, TPartialElement> owner)
    {
      _owner = owner;
    }
    public abstract TPartialElement Current { get; }

    public async ValueTask DisposeAsync()
    {
      await OnDispose();
      IsDisposed = true;
      await _owner.PartialDisposed();
    }

    public abstract ValueTask<bool> MoveNextAsync();

    protected virtual ValueTask OnDispose()
    {
      return default;
    }

    internal abstract ValueTask AddElement(TCompositeElement element);
    internal abstract ValueTask FinishedAdding();

  }
}
