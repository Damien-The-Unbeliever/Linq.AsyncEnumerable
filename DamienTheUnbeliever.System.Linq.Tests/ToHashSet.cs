using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class ToHashSet
  {
    [Fact]
    public void Throws_On_Null_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var result = AsyncEnumerable.ToHashSet<int>(null);
      });
    }

    [Fact]
    public void Throws_On_Null_Source_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var result = AsyncEnumerable.ToHashSet<int>(null,new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_Set()
    {
      var actual =await  AsyncEnumerable.Empty<int>().ToHashSet();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_Set_Comparer()
    {
      var actual = await AsyncEnumerable.Empty<int>().ToHashSet(new IntComparer());

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Multiple_Repeats_Eliminated()
    {
      var source = Enumerable.Repeat(5, 4).Concat(Enumerable.Repeat(7, 2)).Concat(Enumerable.Repeat(5, 4)).AsAsyncEnumerable();

      var actual = await source.ToHashSet();

      Assert.Equal(2, actual.Count);
      Assert.Contains(5, actual);
      Assert.Contains(7, actual);
    }

    [Fact]
    public async Task Multiple_Repeats_Elimiated_With_ModComparer()
    {
      var source = new int[] { 5, 8, 9, 10 };

      var actual = await source.AsAsyncEnumerable().ToHashSet(new ModComparer());

      Assert.Equal(3, actual.Count);
    }
  }
}
