using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class SequenceEqual
  {
    [Fact]
    public void Eagerly_Validates_First()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SequenceEqual(null, AsyncEnumerable.Empty<int>());
      });
    }

    [Fact]
    public void Eagerly_Validates_Second()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SequenceEqual(AsyncEnumerable.Empty<int>(), null);
      });
    }

    [Fact]
    public void Eagerly_Validates_First_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SequenceEqual(null, AsyncEnumerable.Empty<int>(), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Second_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SequenceEqual(AsyncEnumerable.Empty<int>(), null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequences_Are_Equal()
    {
      var first = AsyncEnumerable.Empty<int>();
      var second = AsyncEnumerable.Empty<int>();

      Assert.True(await first.SequenceEqual(second));
    }

    [Fact]
    public async Task Sequences_Equal_Custom_Comparer()
    {
      var first = Enumerable.Range(0, 4).AsAsyncEnumerable();
      var second = Enumerable.Range(8, 4).AsAsyncEnumerable();

      Assert.True(await first.SequenceEqual(second, new ModComparer()));
    }

    [Fact]
    public async Task Unequal_Sequences_Length_First_Unequal()
    {
      var first = Enumerable.Range(0, 4).AsAsyncEnumerable();
      var second = Enumerable.Range(0, 3).AsAsyncEnumerable();

      Assert.False(await first.SequenceEqual(second));
    }

    [Fact]
    public async Task Unequal_Sequences_Length_Second_Unequal()
    {
      var first = Enumerable.Range(0, 4).AsAsyncEnumerable();
      var second = Enumerable.Range(0, 5).AsAsyncEnumerable();

      Assert.False(await first.SequenceEqual(second));
    }
    [Fact]
    public async Task Unequal_Sequences_Values_Unequal()
    {
      var first = Enumerable.Range(0, 4).AsAsyncEnumerable();
      var second = Enumerable.Range(0, 3).Append(19).AsAsyncEnumerable();

      Assert.False(await first.SequenceEqual(second));
    }

  }
}
