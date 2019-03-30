using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Contains
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Contains(null, 4);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Contains<int>(null, 4, new IntComparer());
      });
    }

    [Fact]
    public async Task Can_Find_Element_Default()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable();

      var actual = await source.Contains(5);

      Assert.True(actual);
    }

    [Fact]
    public async Task Can_Fail_To_Find_Default()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable();

      var actual = await source.Contains(15);

      Assert.False(actual);
    }

    [Fact]
    public async Task Can_Find_Using_Comparer()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable();

      var actual = await source.Contains(15, new ModComparer());

      Assert.True(actual);
    }
  }
}
