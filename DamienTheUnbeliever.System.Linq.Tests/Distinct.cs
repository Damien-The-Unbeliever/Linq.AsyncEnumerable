using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{

  public class Distinct
  {
    [Fact]
    public void Eagerly_Validates_Source_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Distinct((IAsyncEnumerable<int>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_With_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Distinct((IAsyncEnumerable<int>)null, null);
      });
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source()
    {
      var target = new ThrowingAsyncEnumerable<long>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await using(var iter = target.Distinct().GetAsyncEnumerator())
        {
          await iter.MoveNextAsync();
        }
      });
    }
    [Fact]
    public async Task Empty_Sequence_Still_Empty()
    {
      var target = AsyncEnumerable.Empty<long>();

      var actual = await target.Distinct().ToList();

      Assert.Empty(actual);
    }
    [Fact]
    public async Task Repeated_Elements_Flattened()
    {
      var target = AsyncEnumerable.Repeat(19, 7);

      var actual = await target.Distinct().ToList();

      Assert.Single(actual);
      Assert.Equal(19, actual[0]);
    }
    [Fact]
    public async Task Custom_Comparer_Respected()
    {
      var target = Enumerable.Range(0, 30).AsAsyncEnumerable();

      var actual = await target.Distinct(new ModComparer()).ToList();

      Assert.Equal(4, actual.Count);
    }
  }
}
