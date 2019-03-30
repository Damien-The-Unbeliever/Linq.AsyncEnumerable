using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class Cast
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Cast<int, object>((IAsyncEnumerable<int>)null);
      });
    }

    [Fact]
    public async Task Awaiting_Causes_Iteration()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await using (var items = AsyncEnumerable.Cast<int, object>(target).GetAsyncEnumerator())
        {
          await items.MoveNextAsync();
        }
      });
    }

    [Fact]
    public async Task CanSucceed()
    {
      var target = Enumerable.Range(0, 4);

      var actual = await target.AsAsyncEnumerable().Cast<int, object>().ToList();

      Assert.NotEmpty(actual);
    }

    [Fact]
    public async Task CanThrow()
    {
      var target = Enumerable.Range(0, 4);

      await Assert.ThrowsAsync<InvalidCastException>(async () =>
      {
        var actual = await target.AsAsyncEnumerable().Cast<int, Action>().ToList();
      });
    }
  }
}
