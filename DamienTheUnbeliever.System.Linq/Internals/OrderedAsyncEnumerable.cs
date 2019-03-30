using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal class OrderedAsyncEnumerable<TElement, TKey> : CompositeAsyncEnumerable<TElement, TElement>, IOrderedAsyncEnumerable<TElement>
  {
    private readonly IAsyncEnumerable<TElement> _inner;
    private readonly IComparer<TKey> _comparer;
    private readonly Func<TElement, Task<TKey>>? _keySelector;
    private readonly Func<TElement, ValueTask<TKey>>? _valueKeySelector;
    internal OrderedAsyncEnumerable(IAsyncEnumerable<TElement> inner, IComparer<TKey> comparer, Func<TElement, Task<TKey>>? keySelector, Func<TElement, ValueTask<TKey>>? valueKeySelector)
    {
      _inner = inner;
      _comparer = comparer;
      _keySelector = keySelector;
      _valueKeySelector = valueKeySelector;
    }
    public IOrderedAsyncEnumerable<TElement> CreateOrderedEnumerable<TKey1>(Func<TElement, ValueTask<TKey1>> keySelector, IComparer<TKey1>? comparer, bool descending)
    {
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      comparer ??= Comparer<TKey1>.Default;
      if (descending)
      {
        comparer = new ReverseComparer<TKey1>(comparer);
      }
      var currentKeySelector = _keySelector??(a=>_valueKeySelector!(a).AsTask());
      async Task<(TKey, TKey1)> newKeySelector(TElement a) => (await currentKeySelector(a), await keySelector(a));
      var newKeyComparer = new CompositeComparer<TKey, TKey1>(_comparer, comparer);

      return new OrderedAsyncEnumerable<TElement, (TKey, TKey1)>(_inner, newKeyComparer, newKeySelector, null);
    }

    public IOrderedAsyncEnumerable<TElement> CreateOrderedEnumerable<TKey1>(Func<TElement, Task<TKey1>> keySelector, IComparer<TKey1>? comparer, bool descending)
    {
      if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
      comparer ??= Comparer<TKey1>.Default;
      if (descending)
      {
        comparer = new ReverseComparer<TKey1>(comparer);
      }
      var currentKeySelector = _keySelector ?? (a => _valueKeySelector!(a).AsTask());
      async Task<(TKey, TKey1)> newKeySelector(TElement a) => (await currentKeySelector(a), await keySelector(a));
      var newKeyComparer = new CompositeComparer<TKey, TKey1>(_comparer, comparer);

      return new OrderedAsyncEnumerable<TElement, (TKey, TKey1)>(_inner, newKeyComparer, newKeySelector, null);
    }

    public override IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      return new OrderedAsyncEnumerator<TElement, TKey>(_inner.GetAsyncEnumerator(), _comparer, _keySelector, _valueKeySelector).Results;
    }
  }

  internal class OrderedAsyncEnumerator<TElement, TKey> : CompositeAsyncEnumerator<TElement, TElement>, IAsyncEnumerator<TElement>
  {
    internal readonly IComparer<TKey> _comparer;
    internal readonly Func<TElement, Task<TKey>>? _keySelector;
    internal readonly Func<TElement, ValueTask<TKey>>? _valueKeySelector;
    public PartialSortResults Results { get; }
    public OrderedAsyncEnumerator(IAsyncEnumerator<TElement> inner, IComparer<TKey> comparer, Func<TElement, Task<TKey>>? keySelector, Func<TElement, ValueTask<TKey>>? valueKeySelector) : base(inner)
    {
      _comparer = comparer;
      _keySelector = keySelector;
      _valueKeySelector = valueKeySelector;
      Results = new PartialSortResults(this);
    }

    public override async ValueTask<bool> MoveNextAsync()
    {
      while (await MoveNextInternal())
      {
      }
      return false;
    }

    protected override IEnumerable<PartialAsyncEnumerator<TElement, TElement>> AllPartials()
    {
      yield return Results;
    }

    protected override IEnumerable<PartialAsyncEnumerator<TElement, TElement>> SelectedPartials(TElement element)
    {
      yield return Results;
    }

    internal class PartialSortResults : PartialAsyncEnumerator<TElement, TElement>
    {
      private readonly PartialAsyncCollection<(TElement, TKey)> _inProgress = new PartialAsyncCollection<(TElement, TKey)>(() => Task.CompletedTask);
      private readonly TaskCompletionSource<bool> _complete = new TaskCompletionSource<bool>();
      private IAsyncEnumerator<TElement>? _sorted;
      private readonly bool _useValue;
      private readonly Lazy<ValueTask> _hasMoved;
      public PartialSortResults(OrderedAsyncEnumerator<TElement, TKey> owner) : base(owner)
      {
        _useValue = owner._valueKeySelector != null;
        _hasMoved = new Lazy<ValueTask>(async () =>
        {
          await owner.MoveNextAsync();
        }, LazyThreadSafetyMode.ExecutionAndPublication);
      }

      public override TElement Current => _sorted!.Current;

      public override async ValueTask<bool> MoveNextAsync()
      {
        await _hasMoved.Value;
        await _complete.Task;
        return await _sorted!.MoveNextAsync();
      }

      public OrderedAsyncEnumerator<TElement, TKey> Owner => (OrderedAsyncEnumerator<TElement, TKey>)_owner;

      internal override async ValueTask AddElement(TElement element)
      {
        TKey key;
        if (_useValue)
        {
          key = await Owner._valueKeySelector!(element);
        }
        else
        {
          key = await Owner._keySelector!(element);
        }
        await _inProgress.AddAdditionalElement((element, key));
      }

      internal override async ValueTask FinishedAdding()
      {
        await _inProgress.CompleteAdding();
        var builder = new Queue<IAsyncEnumerator<(TElement, TKey)>>();
        await foreach (var item in _inProgress)
        {
          builder.Enqueue(Wrap(item));
        }
        if (builder.Count == 0)
        {
          _sorted = AsyncEnumerable.Empty<TElement>().GetAsyncEnumerator();
          _complete.SetResult(true);
        }
        while (builder.Count > 1)
        {
          var otherBuilder = new Queue<IAsyncEnumerator<(TElement, TKey)>>();
          while (builder.Count > 0)
          {
            var first = builder.Dequeue();
            if (builder.TryDequeue(out var second))
            {
              otherBuilder.Enqueue(Composite(first, second));
            }
            else
            {
              otherBuilder.Enqueue(first);
            }
          }
          builder = otherBuilder;
        }
        _sorted = Unwrap(builder.Dequeue());
        _complete.SetResult(true);
      }
      private async IAsyncEnumerator<TElement> Unwrap(IAsyncEnumerator<(TElement, TKey)> toUnwrap)
      {
        while (await toUnwrap.MoveNextAsync())
        {
          yield return toUnwrap.Current.Item1;
        }
      }
      private async IAsyncEnumerator<(TElement, TKey)> Composite(IAsyncEnumerator<(TElement, TKey)> first, IAsyncEnumerator<(TElement, TKey)> second)
      {
        if (await first.MoveNextAsync())
        {
          if (await second.MoveNextAsync())
          {
            while (true)
            {
              if (Owner._comparer.Compare(first.Current.Item2, second.Current.Item2) <= 0)
              {
                yield return first.Current;
                if (!await first.MoveNextAsync()) {
                  do
                  {
                    yield return second.Current;
                  } while (await second.MoveNextAsync());
                  yield break;
                }
              }
              else
              {
                yield return second.Current;
                if (!await second.MoveNextAsync())
                {
                  do
                  {
                    yield return first.Current;
                  } while (await first.MoveNextAsync());
                  yield break;
                }
              }
            }
          }
          else
          {
            do
            {
              yield return first.Current;
            } while (await first.MoveNextAsync());
            yield break;
          }
        }
        else
        {
          while(await second.MoveNextAsync())
          {
            yield return second.Current;
          }
          yield break;
        }
      }

      private async IAsyncEnumerator<(TElement, TKey)> Wrap((TElement, TKey) toWrap)
      {
        yield return toWrap;
        await Task.Yield();
      }
    }
  }
}
