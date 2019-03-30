using System;
using System.Collections.Generic;
using System.Text;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal class ReverseComparer<TKey> : IComparer<TKey>
  {
    private readonly IComparer<TKey> _inner;
    public ReverseComparer(IComparer<TKey> inner)
    {
      _inner = inner;
    }
    public int Compare(TKey x, TKey y)
    {
      return _inner.Compare(y, x);
    }
  }
}
