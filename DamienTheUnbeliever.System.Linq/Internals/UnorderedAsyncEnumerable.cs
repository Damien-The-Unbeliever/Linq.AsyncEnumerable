using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal class UnorderedAsyncEnumerable<TElement> : CompositeAsyncEnumerable<Task<TElement>, TElement>, IUnorderedAsyncEnumerable<TElement>
  {
    private readonly IAsyncEnumerable<Task<TElement>> _inner;
    public UnorderedAsyncEnumerable(IAsyncEnumerable<Task<TElement>> inner)
    {
      _inner = inner;
    }
    public override IAsyncEnumerator<Task<TElement>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      return new Enumerator(_inner.GetAsyncEnumerator());
    }

    IAsyncEnumerator<TElement> IAsyncEnumerable<TElement>.GetAsyncEnumerator(CancellationToken cancellationToken)
    {
      return new Enumerator(_inner.GetAsyncEnumerator()).Final;
    }

    public class Enumerator : CompositeAsyncEnumerator<Task<TElement>, TElement>
    {
      public Accumulator Final { get; }
      public Enumerator(IAsyncEnumerator<Task<TElement>> inner) : base(inner)
      {
        Final = new Accumulator(this);
      }

      public override ValueTask<bool> MoveNextAsync()
      {
        throw new NotImplementedException();
      }

      protected override IEnumerable<PartialAsyncEnumerator<Task<TElement>, TElement>> AllPartials()
      {
        yield return Final;
      }

      protected override IEnumerable<PartialAsyncEnumerator<Task<TElement>, TElement>> SelectedPartials(Task<TElement> element)
      {
        yield return Final;
      }
      public class Accumulator : PartialAsyncEnumerator<Task<TElement>, TElement>
      {
        private readonly ConcurrentBag<Task<TElement>> _items;
        private bool _complete;

        public Accumulator(Enumerator owner) : base(owner)
        {
          _items = new ConcurrentBag<Task<TElement>>
          {
            Task.FromException<TElement>(new InvalidOperationException())
          };
          _complete = false;
        }

        public override TElement Current
        {
          get
          {
            if (_items.TryPeek(out var current)) return current.Result;
            throw new InvalidOperationException();
          }
        }

        public override async ValueTask<bool> MoveNextAsync()
        {
          _items.TryTake(out var _);
          while (true)
          {
            if (_items.Count > 0) return true;
            if (_complete && _items.Count == 0) return false;
            var waits = _items.Cast<Task>().AsEnumerable();
            if (!_complete)
            {
              var mni = _owner.MoveNextInternal().AsTask();
              waits = waits.Append(mni.ContinueWith(final => { if (!final.Result) _complete = true; }));
              await Task.WhenAny(waits);
            }
            else
            {
              await Task.WhenAny(waits);
            }
          }
        }

        internal override ValueTask AddElement(Task<TElement> element)
        {
          _items.Add(element);
          return default;
        }

        internal override ValueTask FinishedAdding()
        {
          return default;
        }
      }
    }
  }
}
