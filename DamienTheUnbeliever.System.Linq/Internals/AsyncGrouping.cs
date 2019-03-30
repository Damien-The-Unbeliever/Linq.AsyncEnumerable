using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal sealed class AsyncGrouping<TKey, TElement> : IAsyncGrouping<TKey, TElement>
  {
    private PartialAsyncCollection<TElement>? _inProgress;
    private List<TElement>? _completed;

    internal bool HasBeenInit { get; private set; }

    public TKey Key { get; }

    public AsyncGrouping(TKey key, Func<Task> requestMore, params TElement[] originals)
    {
      Key = key;
      _inProgress = new PartialAsyncCollection<TElement>(requestMore, originals);
    }

    public IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      var wrapped = (IAsyncEnumerable<TElement>?)_inProgress ?? new AsyncWrappedEnumerable<TElement>(_completed!);
      return wrapped.GetAsyncEnumerator();
    }

    public async Task AddElement(TElement element)
    {
      var inProgress = _inProgress;
      HasBeenInit = true;
      if (inProgress == null) throw new NotSupportedException("Grouping already complete");
      await inProgress.AddAdditionalElement(element);
    }

    public async Task MarkComplete()
    {
      var inProgress = _inProgress;
      if (inProgress == null) throw new NotSupportedException("Grouping already complete");
      await inProgress.CompleteAdding();
      _completed = await inProgress.ToList();
      Interlocked.Exchange(ref _inProgress, null!);
    }
  }
}
