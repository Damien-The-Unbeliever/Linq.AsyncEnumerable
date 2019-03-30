using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class Prepend
  {
    [Fact]
    public void Eager_Validation_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Prepend<int>(null, 0);
      });
    }

    [Fact]
    public void Eager_Validation_Source_WithTask()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Prepend<int>(null, Task.FromResult(0));
      });
    }
    [Fact]
    public void Eager_Validation_Source_WithValueTask()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Prepend<int>(null, new ValueTask<int>(0));
      });
    }
    [Fact]
    public void Eager_Validation_Task()
    {
      var target = new ThrowingAsyncEnumerable<int>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Prepend(target, (Task<int>)null);
      });
    }

    [Fact]
    public async Task Starting_Iteration_Forces_Iteration()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await using (var iter = target.Prepend(0).GetAsyncEnumerator())
      {
        await iter.MoveNextAsync();
        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {

          await iter.MoveNextAsync();
        });
      }
    }

    [Fact]
    public async Task Prepend_Works()
    {
      var expected = new List<int> { 4, 1, 2, 3 };
      var target = new TasksWithDelays<int>((1, 0), (2, 10), (3, 0));

      var actual = await target.AsAsyncEnumerable().Prepend(4).ToList();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Prepend_Works_WithTask()
    {
      var expected = new List<int> { 4, 1, 2, 3 };
      var target = new TasksWithDelays<int>((1, 0), (2, 10), (3, 0));

      var actual = await target.AsAsyncEnumerable().Prepend(Task.FromResult(4)).ToList();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Prepend_Works_WithValueTask()
    {
      var expected = new List<int> { 4, 1, 2, 3 };
      var target = new TasksWithDelays<int>((1, 0), (2, 10), (3, 0));

      var actual = await target.AsAsyncEnumerable().Prepend(new ValueTask<int>(4)).ToList();

      Assert.Equal(expected, actual);
    }
  }
}
