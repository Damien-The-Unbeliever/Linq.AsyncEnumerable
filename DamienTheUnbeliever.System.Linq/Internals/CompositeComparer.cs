using System;
using System.Collections.Generic;
using System.Text;

namespace DamienTheUnbeliever.System.Linq.Internals
{
  internal class CompositeComparer<TKey,TKey2> : IComparer<(TKey,TKey2)>
  {
    private readonly IComparer<TKey> _first;
    private readonly IComparer<TKey2> _second;
    public CompositeComparer(IComparer<TKey> first, IComparer<TKey2> second)
    {
      _first = first;
      _second = second;
    }

    public int Compare((TKey,TKey2) x, (TKey,TKey2) y)
    {
      var result1 = _first.Compare(x.Item1, y.Item1);
      if (result1 != 0) return result1;
      return _second.Compare(x.Item2, y.Item2);
    }
  }
}
