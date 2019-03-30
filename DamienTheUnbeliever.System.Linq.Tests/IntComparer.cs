using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  internal class IntComparer : IComparer<int>, IEqualityComparer<int>
  {
    public int Compare(int x, int y)
    {
      return x.CompareTo(y);
    }

    public bool Equals(int x, int y)
    {
      return x == y;
    }

    public int GetHashCode(int obj)
    {
      return obj.GetHashCode();
    }
  }

}
