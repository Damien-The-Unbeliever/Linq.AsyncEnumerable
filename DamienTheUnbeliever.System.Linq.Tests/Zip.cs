using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Zip
  {
    [Fact]
    public void Eagerly_Validates_First_Plain_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip((IAsyncEnumerable<int>)null, AsyncEnumerable.Empty<int>(), (a, b) => new { a, b });
      });
    }

    [Fact]
    public void Eagerly_Validates_Second_Plain_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip(AsyncEnumerable.Empty<int>(), (IAsyncEnumerable<int>)null, (a, b) => new { a, b });
      });
    }

    [Fact]
    public void Eagerly_Validates_Plain_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), (Func<int,int,int>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_First_Task_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip((IAsyncEnumerable<int>)null, AsyncEnumerable.Empty<int>(), (a, b) => Task.FromResult(new { a, b }));
      });
    }

    [Fact]
    public void Eagerly_Validates_Second_Task_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip(AsyncEnumerable.Empty<int>(), (IAsyncEnumerable<int>)null, (a, b) => Task.FromResult(new { a, b }));
      });
    }

    [Fact]
    public void Eagerly_Validates_Task_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), (Func<int, int, Task<int>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_First_ValueTask_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip((IAsyncEnumerable<int>)null, AsyncEnumerable.Empty<int>(), (a, b) => new ValueTask<int>(a+b));
      });
    }

    [Fact]
    public void Eagerly_Validates_Second_ValueTask_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip(AsyncEnumerable.Empty<int>(), (IAsyncEnumerable<int>)null, (a, b) => new ValueTask<int>(a + b));
      });
    }

    [Fact]
    public void Eagerly_Validates_ValueTask_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Zip(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), (Func<int, int, ValueTask<int>>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequences_Produce_Empty_Sequence_Plain()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable();
      var second = AsyncEnumerable.Empty<int>();

      var actual = await first.Zip(second, (a, b) => new { a, b }).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Sequences_Produce_Empty_Sequence_Task()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable();
      var second = AsyncEnumerable.Empty<int>();

      var actual = await first.Zip(second, (a, b) => Task.FromResult(new { a, b })).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Sequences_Produce_Empty_Sequence_ValueTask()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable();
      var second = AsyncEnumerable.Empty<int>();

      var actual = await first.Zip(second, (a, b) => new ValueTask<int>(a + b)).ToList(); ;

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Combines_Values_ValueTask()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable();

      var second = Enumerable.Range(0, 5).AsAsyncEnumerable();

      var actual = await first.Zip(second, (a, b) => a + b).ToList();

      Assert.Equal(5, actual.Count);

      Assert.Contains(8, actual);
    }

    [Fact]
    public async Task Combines_Values_Task()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable();

      var second = Enumerable.Range(0, 5).AsAsyncEnumerable();

      var actual = await first.Zip(second, (a, b) => Task.FromResult(a + b)).ToList();

      Assert.Equal(5, actual.Count);

      Assert.Contains(8, actual);
    }

  }
}
