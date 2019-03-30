using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals.Tasks
{
  internal class AsyncLookup<TSource, TKey, TElement> :IAsyncLookup<TKey, TElement>
  {

    internal AsyncLookup(
      IAsyncEnumerable<TSource> source,
      Func<TSource, Task<TKey>> keySelector,
      Func<TSource, Task<TElement>> elementSelector,
      IEqualityComparer<TKey> keyComparer)
    {
      _keySelector = keySelector;
      _elementSelector = elementSelector;
      _iterator = source.GetAsyncEnumerator();
      _factory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(1));
      _dictionary = new ConcurrentDictionary<TKey, AsyncGrouping<TKey, TElement>>(keyComparer);
      _completed = new TaskCompletionSource<bool>();
      _inProgress = new PartialAsyncCollection<AsyncGrouping<TKey, TElement>>(MoveNextUntied);
    }

    private Func<TSource, Task<TKey>>? _keySelector;
    private Func<TSource, Task<TElement>>? _elementSelector;
    private IAsyncEnumerator<TSource>? _iterator;
    private readonly TaskFactory _factory;
    private readonly ConcurrentDictionary<TKey, AsyncGrouping<TKey, TElement>> _dictionary;
    private readonly TaskCompletionSource<bool> _completed;
    private PartialAsyncCollection<AsyncGrouping<TKey, TElement>>? _inProgress;

    private async Task MoveNextUntied()
    {
      await _factory.StartNew(MoveNextInternal).Unwrap();
    }
    private async Task<bool> ContainsKeyInternal(TKey key)
    {
      //Must be executed on _factory
      while (true)
      {
        if (_dictionary.ContainsKey(key)) return true;
        if (_completed.Task.IsCompleted) return false;
        await MoveNextInternal();
      }
    }
    private async Task MoveNextInternal()
    {
      //Must be executed on _factory
      if (_inProgress == null) return;
      Debug.Assert(_iterator != null);
      Debug.Assert(_keySelector != null);
      Debug.Assert(_elementSelector != null);

      var stillRunning = await _iterator.MoveNextAsync();
      if (stillRunning)
      {
        var key = await _keySelector(_iterator.Current);
        var ele = await _elementSelector(_iterator.Current);

        var grouping = _dictionary.GetOrAdd(key, _ => new AsyncGrouping<TKey, TElement>(key, MoveNextUntied));
        if (!grouping.HasBeenInit)
        {
          await _inProgress.AddAdditionalElement(grouping);
        }
        await grouping.AddElement(ele);
      }
      else
      {
        await CompleteIteration();
      }
    }
    private async Task CompleteIteration()
    {
      //Should only be called by MoveNextInternal
      Debug.Assert(_inProgress != null);
      foreach (var grouping in _dictionary.Values)
      {
        await grouping.MarkComplete();
      }
      await _inProgress.CompleteAdding();
      _completed.TrySetResult(true);
      _inProgress = null;
      //Clear out other items we'll no longer need
      _keySelector = null;
      _elementSelector = null;
      _iterator = null;
    }

    public async Task<int> GetCount()
    {
      while (!_completed.Task.IsCompleted)
      {
        await MoveNextUntied();
      }
      return _dictionary.Count;
    }

    public async Task<bool> ContainsKey(TKey key)
    {
      return await _factory.StartNew(() => ContainsKeyInternal(key)).Unwrap();
    }

    public async IAsyncEnumerable<TElement> GetItem(TKey key)
    {
      if (await ContainsKey(key))
      {
        //Ideally we don't add a layer of wrapping but async/IAsyncEnumerable
        //forces this to be an itertor so we cannot directly return the value
        await foreach (var item in _dictionary[key])
        {
          yield return item;
        }
      }
    }


    public IAsyncEnumerator<IAsyncGrouping<TKey, TElement>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      var enumerable = _inProgress ?? _dictionary.Values.AsAsyncEnumerable();

      return enumerable.GetAsyncEnumerator(cancellationToken);
    }
  }
}