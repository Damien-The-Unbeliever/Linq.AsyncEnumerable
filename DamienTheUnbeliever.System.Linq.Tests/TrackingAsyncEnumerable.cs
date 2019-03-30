using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  internal static class TrackingEnumerableExtensions
  {
    public static TrackingAsyncEnumerable<TElement> WithTracking<TElement>(this IAsyncEnumerable<TElement> source)
    {
      return new TrackingAsyncEnumerable<TElement>(source);
    }
  }
  internal class TrackingAsyncEnumerable<TElement> : IAsyncEnumerable<TElement>
  {
    private readonly IAsyncEnumerable<TElement> _inner;
    public TrackingAsyncEnumerable(IAsyncEnumerable<TElement> inner)
    {
      _inner = inner;
      State = Status.Initial;
    }
    public enum Status
    {
      Initial,
      EnumeratorObtained,
      EnumerationComplete
    }
    public long EnumeratorsProvided { get; private set; }
    public long ItemsProvided { get; private set; }
    public Status State { get; private set; }
    public IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      var enu = new Enumerator(_inner.GetAsyncEnumerator(), this);
      EnumeratorsProvided++;
      State = Status.EnumeratorObtained;
      return enu;

    }

    private class Enumerator : IAsyncEnumerator<TElement>
    {
      private readonly IAsyncEnumerator<TElement> _inner;
      private readonly TrackingAsyncEnumerable<TElement> _owner;
      public Enumerator(IAsyncEnumerator<TElement> inner, TrackingAsyncEnumerable<TElement> owner)
      {
        _inner = inner;
        _owner = owner;
      }

      public TElement Current => _inner.Current;

      public async ValueTask DisposeAsync()
      {
        await _inner.DisposeAsync();
        _owner.State = Status.EnumerationComplete;
      }

      public async ValueTask<bool> MoveNextAsync()
      {
        if(await _inner.MoveNextAsync())
        {
          _owner.ItemsProvided++;
          return true;
        }
        else
        {
          _owner.State = Status.EnumerationComplete;
          return false;
        }
      }
    }
  }
}
