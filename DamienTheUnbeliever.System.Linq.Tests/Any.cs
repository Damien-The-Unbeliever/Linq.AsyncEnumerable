using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Any
  {
    [Fact]
    public void Eager_Validation_Source_NoTaskPredicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var noIterate = AsyncEnumerable.Any((IAsyncEnumerable<bool>)null, QuickFunctions<bool>.Identity);
      });
    }

    [Fact]
    public void Eager_Validation_Source_NoPredicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var noIterate = AsyncEnumerable.Any((IAsyncEnumerable<bool>)null);
      });
    }

    [Fact]
    public void Eager_Validation_Predicate_NoTaskPredicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var noIterate = AsyncEnumerable.Any(target, (Func<bool, bool>)null);
      });
    }
    [Fact]
    public void Eager_Validation_Source_TaskPredicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var noIterate = AsyncEnumerable.Any((IAsyncEnumerable<bool>)null, QuickFunctions<bool>.IdentityTasked);
      });
    }

    [Fact]
    public void Eager_Validation_Predicate_TaskPredicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var noIterate = AsyncEnumerable.Any(target, (Func<bool, Task<bool>>)null);
      });
    }
    [Fact]
    public void Eager_Validation_Source_ValueTaskPredicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var noIterate = AsyncEnumerable.Any((IAsyncEnumerable<bool>)null, QuickFunctions<bool>.IdentityWrapped);
      });
    }

    [Fact]
    public void Eager_Validation_Predicate_ValueTaskPredicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      Assert.Throws<ArgumentNullException>(() =>
      {
        var noIterate = AsyncEnumerable.Any(target, (Func<bool, ValueTask<bool>>)null);
      });
    }

    [Fact]
    public async Task Awaiting_Task_Forces_Iteration()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var all = await target.Any(QuickFunctions<bool>.Identity);
      });
    }

    [Fact]
    public async Task CanAnswer_True()
    {
      var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await target.AsAsyncEnumerable().Any(a => a > 0);

      Assert.True(actual);
    }
    [Fact]
    public async Task CanAnswer_False()
    {
      var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await target.AsAsyncEnumerable().Any(a => a > 3);

      Assert.False(actual);
    }
    [Fact]
    public async Task CanAnswer_True_ViaTask()
    {
      var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await target.AsAsyncEnumerable().Any(a => Task.FromResult(a > 0));

      Assert.True(actual);
    }
    [Fact]
    public async Task CanAnswer_False_ViaTask()
    {
      var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await target.AsAsyncEnumerable().Any(a => Task.FromResult(a > 3));

      Assert.False(actual);
    }

    [Fact]
    public async Task CanAnswer_True_ViaValueTask()
    {
      var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await target.AsAsyncEnumerable().Any(a => new ValueTask<bool>(a > 0));

      Assert.True(actual);
    }
    [Fact]
    public async Task CanAnswer_False_ViaValueTask()
    {
      var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await target.AsAsyncEnumerable().Any(a => new ValueTask<bool>(a > 3));

      Assert.False(actual);
    }

    [Fact]
    public async Task CanAnswer_True_NoPredicate()
    {
      var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await target.AsAsyncEnumerable().Any();

      Assert.True(actual);
    }
    [Fact]
    public async Task CanAnswer_False_NoPredicate()
    {

      var actual = await AsyncEnumerable.Empty<int>().Any();

      Assert.False(actual);
    }
  }
}
