using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal abstract class CompositeAsyncEnumerable<TCompositeElement, TPartialElement> : IAsyncEnumerable<TCompositeElement>
  {
    public abstract IAsyncEnumerator<TCompositeElement> GetAsyncEnumerator(CancellationToken cancellationToken = default);
  }

  internal abstract class CompositeAsyncEnumerator<TCompositeElement, TPartialElement> : IAsyncEnumerator<TCompositeElement>
  {
    private readonly IAsyncEnumerator<TCompositeElement> _inner;

    protected CompositeAsyncEnumerator(IAsyncEnumerator<TCompositeElement> inner)
    {
      _inner = inner;
    }
    public TCompositeElement Current => _inner.Current;

    public async ValueTask DisposeAsync()
    {
      await PartialDisposed();
    }

    internal async ValueTask PartialDisposed()
    {
      if (AllPartials().All(p => p.IsDisposed))
      {
        await _inner.DisposeAsync();
      }
    }

    internal async ValueTask<bool> MoveNextInternal()
    {
      if (await _inner.MoveNextAsync())
      {
        foreach (var prt in SelectedPartials(_inner.Current))
        {
          await prt.AddElement(_inner.Current);
        }
        return true;
      }
      else
      {
        foreach (var prt in AllPartials())
        {
          await prt.FinishedAdding();
        }
        return false;
      }
    }

    protected abstract IEnumerable<PartialAsyncEnumerator<TCompositeElement, TPartialElement>> AllPartials();
    protected abstract IEnumerable<PartialAsyncEnumerator<TCompositeElement, TPartialElement>> SelectedPartials(TCompositeElement element);
    public abstract ValueTask<bool> MoveNextAsync();
  }
}
