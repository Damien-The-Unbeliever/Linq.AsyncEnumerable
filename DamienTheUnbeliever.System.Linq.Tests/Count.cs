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
  
  public class Count
  {
    [Fact]
    public void Eagerly_Validates_Source_No_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Count((IAsyncEnumerable<bool>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_Plain_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Count(null,QuickFunctions<bool>.Identity);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_Task_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Count(null, QuickFunctions<bool>.IdentityTasked);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Count(null, QuickFunctions<bool>.IdentityWrapped);
      });
    }
    [Fact]
    public void Eagerly_Validates_Plain_Predicate()
    {
      var target = AsyncEnumerable.Empty<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Count(target, (Func<bool,bool>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Task_Predicate()
    {
      var target = AsyncEnumerable.Empty<bool>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Count(target, (Func<bool,Task<bool>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_ValueTask_Predicate()
    {
      var target = AsyncEnumerable.Empty<bool>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Count(target, (Func<bool, ValueTask<bool>>)null);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_No_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<long>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Count();
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Plain_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Count(QuickFunctions<bool>.Identity);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Task_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Count(QuickFunctions<bool>.IdentityTasked);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_ValueTask_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.Count(QuickFunctions<bool>.IdentityWrapped);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Is_Zero()
    {
      var target = AsyncEnumerable.Empty<long>();

      var actual = await target.Count();

      Assert.Equal(0, actual);
    }
    [Fact]
    public async Task Empty_Sequence_Is_Zero_Tasked()
    {
      var target = AsyncEnumerable.Empty<long>();

      var actual = await target.Count(l=>Task.FromResult(true));

      Assert.Equal(0, actual);
    }
    [Fact]
    public async Task Non_Empty_Sequence_Is_Non_Zero()
    {
      var target = Enumerable.Range(0, 16).AsAsyncEnumerable();

      var actual = await target.Count();

      Assert.Equal(16, actual);
    }
    [Fact]
    public async Task Non_Empty_Sequence_Is_Non_Zero_Tasked()
    {
      var target = Enumerable.Range(0, 16).AsAsyncEnumerable();

      var actual = await target.Count(l => Task.FromResult(l<8));

      Assert.Equal(8, actual);
    }
  }
}
