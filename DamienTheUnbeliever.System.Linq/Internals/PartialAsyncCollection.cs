using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal sealed class PartialAsyncCollection<TElement> : IAsyncEnumerable<TElement>
  {
    private const string CollectionComplete = "Collection has already been completed";
    private readonly Node _emptyHead;
    private readonly Func<Task> _requestMore;
    private Node? _tail;

    public PartialAsyncCollection(Func<Task> requestMore, params TElement[] originals)
    {
      _emptyHead = new Node(default!);
      _tail = _emptyHead;
      _requestMore = requestMore;
      foreach(var item in originals)
      {
        var node = new Node(item);
        _tail.TrySetNext(node); //Assumed always succeeds
        _tail = node;
      }
    }

    public async IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
      Node? current = _emptyHead;
      while (true)
      {
        while (!current.Next.IsCompleted)
        {
          await _requestMore();
        }
        current = await current.Next;
        if (current == null) yield break;
        yield return current.Element;
      }
    }

    public async ValueTask AddAdditionalElement(TElement element)
    {
      var node = new Node(element);
      await ChainTail(node);
    }
    public async ValueTask CompleteAdding()
    {
      await ChainTail(null);
    }

    public async Task<List<TElement>> ToList()
    {
      var list = new List<TElement>();
      await foreach(var item in this)
      {
        list.Add(item);
      }
      return list;
    }

    private async ValueTask ChainTail(Node? node)
    {
      while (true)
      {
        var tail = _tail;
        if (tail == null) throw new NotSupportedException(PartialAsyncCollection<TElement>.CollectionComplete);
        if (tail.TrySetNext(node))
        {
          Interlocked.Exchange(ref _tail, node);
          return;
        }
        await Task.Yield();
      }
    }

    private class Node
    {
      private readonly TaskCompletionSource<Node?> _next;
      public TElement Element { get; }
      public Task<Node?> Next => _next.Task;
      public Node(TElement element)
      {
        Element = element;
        _next = new TaskCompletionSource<Node?>();
      }

      public bool TrySetNext(Node? next)
      {
        return _next.TrySetResult(next);
      }
    }
  }
}
