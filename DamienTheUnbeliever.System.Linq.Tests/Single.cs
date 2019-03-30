using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class Single
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Single((IAsyncEnumerable<int>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_Plain_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Single(null, QuickFunctions<bool>.Identity);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_Task_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Single(null, QuickFunctions<bool>.IdentityTasked);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Single(null, QuickFunctions<bool>.IdentityWrapped);
      });
    }
    [Fact]
    public void Eagerly_Validates_Plain_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Single(AsyncEnumerable.Empty<bool>(), (Func<bool,bool>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Task_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Single(AsyncEnumerable.Empty<bool>(), (Func<bool, Task<bool>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_ValueTask_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Single(AsyncEnumerable.Empty<bool>(), (Func<bool, ValueTask<bool>>)null);
      });
    }

    [Fact]
    public async Task Awaiting_Result_Iterates_Source()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Single();
      });
    }
    [Fact]
    public async Task Awaiting_Result_Iterates_Source_Plain_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Single(QuickFunctions<bool>.Identity);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Iterates_Source_Task_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Single(QuickFunctions<bool>.IdentityTasked);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Iterates_Source_ValueTask_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Single(QuickFunctions<bool>.IdentityWrapped);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Throws()
    {
      var target = AsyncEnumerable.Empty<int>();

      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        await target.Single();
      });
    }
    [Fact]
    public async Task Empty_Sequence_Throws_Task_Predicate()
    {
      var target = AsyncEnumerable.Empty<int>();

      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        await target.Single(a => Task.FromResult(true));
      });
    }
    [Fact]
    public async Task Singleton_Sequence_Returns()
    {
      var target = Enumerable.Repeat(19, 1).AsAsyncEnumerable();

      var actual = await target.Single();

      Assert.Equal(19, actual);
    }
    [Fact]
    public async Task Multi_Sequence_Throws_ValueTask_Predicate()
    {
      var target = Enumerable.Range(18,9).AsAsyncEnumerable();

      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        await target.Single(a => a % 2 == 1);
      });
    }
    [Fact]
    public async Task Multi_Sequence_Returns_Task_Predicate()
    {
      var target = Enumerable.Range(18, 5).AsAsyncEnumerable();

      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        await target.Single(a => Task.FromResult(a % 2 == 1));
      });
    }
  }
}
