using System.Collections.Generic;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  internal class ModComparer : IEqualityComparer<int>
  {
    public bool Equals(int x, int y)
    {
      return (x % 4) == (y % 4);
    }

    public int GetHashCode(int obj)
    {
      return obj % 4;
    }
  }
}
