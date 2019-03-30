using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class DefaultIfEmpty
  {
    [Fact]
    public void Eagerly_Validates_Source_Default_Default()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.DefaultIfEmpty((IAsyncEnumerable<int>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Explicit_Default()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.DefaultIfEmpty(null, 99);
      });
    }

    [Fact]
    public async Task Starting_Iteration_Iterates_Source()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await using(var iter = target.DefaultIfEmpty().GetAsyncEnumerator())
        {
          await iter.MoveNextAsync();
        }
      });
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Explicit()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await using (var iter = target.DefaultIfEmpty(19).GetAsyncEnumerator())
        {
          await iter.MoveNextAsync();
        }
      });
    }

    [Fact]
    public async Task Empty_Yields_Default_Default()
    {
      var target = AsyncEnumerable.Empty<int>();

      var actual = await target.DefaultIfEmpty().ToList();

      Assert.Single(actual);
      Assert.Equal(default, actual[0]);
    }

    [Fact]
    public async Task Empty_Yields_Explicit_Default()
    {
      var target = AsyncEnumerable.Empty<int>();

      var actual = await target.DefaultIfEmpty(19).ToList();

      Assert.Single(actual);
      Assert.Equal(19, actual[0]);
    }

    [Fact]
    public async Task Non_Empty_Yields_Non_Empty_Without_Default_Default()
    {
      var target = Enumerable.Repeat(7, 1).AsAsyncEnumerable();

      var actual = await target.DefaultIfEmpty().ToList();

      Assert.Single(actual);
      Assert.DoesNotContain(default, actual);
    }
    [Fact]
    public async Task Non_Empty_Yields_Non_Empty_Without_Explicit_Default()
    {
      var target = Enumerable.Repeat(7, 1).AsAsyncEnumerable();

      var actual = await target.DefaultIfEmpty(19).ToList();

      Assert.Single(actual);
      Assert.DoesNotContain(19, actual);
    }
  }
}
