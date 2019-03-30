using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class ToList
  {
    [Fact]
    public void Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.ToList<int>(null);
      });
    }
  }
}
