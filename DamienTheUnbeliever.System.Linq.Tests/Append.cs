using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Append
  {
    [Fact]
    public void Eager_Validation_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Append<int>(null, 0);
      });
    }

    [Fact]
    public void Eager_Validation_Source_WithTask()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Append<int>(null, Task.FromResult(0));
      });
    }
    [Fact]
    public void Eager_Validation_Source_WithValueTask()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Append<int>(null, new ValueTask<int>(0));
      });
    }
    [Fact]
    public void Eager_Validation_Task()
    {
      var target = new ThrowingAsyncEnumerable<int>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Append(target,(Task<int>)null);
      });
    }

    [Fact]
    public async Task Starting_Iteration_Forces_Iteration()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await using(var iter = target.Append(0).GetAsyncEnumerator())
        {
          await iter.MoveNextAsync();
        }
      });
    }

    [Fact]
    public async Task Append_Works()
    {
      var expected = new List<int> { 1, 2, 3, 4 };
      var target = new TasksWithDelays<int>((1, 0), (2, 10), (3, 0));

      var actual = await target.AsAsyncEnumerable().Append(4).ToList();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Append_Works_WithTask()
    {
      var expected = new List<int> { 1, 2, 3, 4 };
      var target = new TasksWithDelays<int>((1, 0), (2, 10), (3, 0));

      var actual = await target.AsAsyncEnumerable().Append(Task.FromResult(4)).ToList();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Append_Works_WithValueTask()
    {
      var expected = new List<int> { 1, 2, 3, 4 };
      var target = new TasksWithDelays<int>((1, 0), (2, 10), (3, 0));

      var actual = await target.AsAsyncEnumerable().Append(new ValueTask<int>(4)).ToList();

      Assert.Equal(expected, actual);
    }
  }
}
