using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  internal class LongComparer : IComparer<long>
  {
    public int Compare(long x, long y)
    {
      return x.CompareTo(y);
    }
  }

}
