using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class Concat
  {
    [Fact]
    public void Eager_Validation_First()
    {
      var second = AsyncEnumerable.Empty<int>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Concat(null, second);
      });
    }

    [Fact]
    public void Eager_Validation_Second()
    {
      var first = AsyncEnumerable.Empty<int>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Concat(first, null);
      });
    }
    [Fact]
    public async Task Awaiting_First_Causes_Iteration()
    {
      var first = new ThrowingAsyncEnumerable<int>();
      var second = AsyncEnumerable.Empty<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await using (var item = first.Concat(second).GetAsyncEnumerator())
        {
          await item.MoveNextAsync();
        }
      });
    }
    [Fact]
    public async Task Awaiting_Second_Causes_Iteration()
    {
      var first = AsyncEnumerable.Empty<int>();
      var second = new ThrowingAsyncEnumerable<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await using (var item = first.Concat(second).GetAsyncEnumerator())
        {
          await item.MoveNextAsync();
        }
      });
    }
    [Fact]
    public async Task Empty_Sequences_Produce_Empty()
    {
      var first = AsyncEnumerable.Empty<int>();
      var second = AsyncEnumerable.Empty<int>();

      var result = await first.Concat(second).Any();

      Assert.False(result);
    }

    [Fact]
    public async Task First_Before_Second()
    {
      var first = Enumerable.Range(0, 2).AsAsyncEnumerable();
      var second = Enumerable.Range(2, 2).AsAsyncEnumerable();
      var expected = Enumerable.Range(0, 4).ToList();

      var actual = await first.Concat(second).ToList();

      Assert.Equal(expected, actual);
    }
  }
}
