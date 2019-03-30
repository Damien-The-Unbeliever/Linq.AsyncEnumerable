using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class TakeWhile
  {
    [Fact]
    public void Eagerly_Validates_Source_Plain_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile((IAsyncEnumerable<int>)null, a => a < 2);
      });
    }

    [Fact]
    public void Eagerly_Validates_Plain_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile(AsyncEnumerable.Empty<int>(), (Func<int, bool>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Plain_Predicate_Indexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile((IAsyncEnumerable<int>)null, (a,i) => a < 2);
      });
    }

    [Fact]
    public void Eagerly_Validates_Plain_Predicate_Indexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile(AsyncEnumerable.Empty<int>(), (Func<int, int, bool>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile((IAsyncEnumerable<int>)null, a => Task.FromResult(a < 2));
      });
    }

    [Fact]
    public void Eagerly_Validates_Task_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile(AsyncEnumerable.Empty<int>(), (Func<int, Task<bool>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Predicate_Indexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile((IAsyncEnumerable<int>)null, (a, i) => Task.FromResult(a < 2));
      });
    }

    [Fact]
    public void Eagerly_Validates_Task_Predicate_Indexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile(AsyncEnumerable.Empty<int>(), (Func<int, int, Task<bool>>)null);
      });
    }


    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile((IAsyncEnumerable<int>)null, a => new ValueTask<bool>(a < 2));
      });
    }

    [Fact]
    public void Eagerly_Validates_ValueTask_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<bool>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Predicate_Indexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile((IAsyncEnumerable<int>)null, (a, i) => new ValueTask<bool>(a < 2));
      });
    }

    [Fact]
    public void Eagerly_Validates_ValueTask_Predicate_Indexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.TakeWhile(AsyncEnumerable.Empty<int>(), (Func<int, int, ValueTask<bool>>)null);
      });
    }

    [Fact]
    public async Task TakeWhile_Plain_Unindexed()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.TakeWhile(a=> a < 5).ToList();

      Assert.Equal(5, actual.Count);
      Assert.Equal(0, actual[0]);
      Assert.Equal(0, actual.Count(i => i == 8));
      Assert.Equal(1, actual.Count(i => i == 2));
    }

    [Fact]
    public async Task TakeWhile_Task_Unindexed()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.TakeWhile(a => Task.FromResult(a < 5)).ToList();

      Assert.Equal(5, actual.Count);
      Assert.Equal(0, actual[0]);
      Assert.Equal(0, actual.Count(i => i == 8));
      Assert.Equal(1, actual.Count(i => i == 2));
    }

    [Fact]
    public async Task TakeWhile_ValueTask_Unindexed()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.TakeWhile(a => new ValueTask<bool>(a < 5)).ToList();

      Assert.Equal(5, actual.Count);
      Assert.Equal(0, actual[0]);
      Assert.Equal(0, actual.Count(i => i == 8));
      Assert.Equal(1, actual.Count(i => i == 2));
    }

    [Fact]
    public async Task TakeWhile_Plain_Indexed()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.TakeWhile((a,i) => a < 5).ToList();

      Assert.Equal(5, actual.Count);
      Assert.Equal(0, actual[0]);
      Assert.Equal(0, actual.Count(i => i == 8));
      Assert.Equal(1, actual.Count(i => i == 2));
    }

    [Fact]
    public async Task TakeWhile_Task_Indexed()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.TakeWhile((a, i) => Task.FromResult(a < 5)).ToList();

      Assert.Equal(5, actual.Count);
      Assert.Equal(0, actual[0]);
      Assert.Equal(0, actual.Count(i => i == 8));
      Assert.Equal(1, actual.Count(i => i == 2));
    }

    [Fact]
    public async Task TakeWhile_ValueTask_Indexed()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.TakeWhile((a, i) => new ValueTask<bool>(a < 5)).ToList();

      Assert.Equal(5, actual.Count);
      Assert.Equal(0, actual[0]);
      Assert.Equal(0, actual.Count(i => i == 8));
      Assert.Equal(1, actual.Count(i => i == 2));
    }
  }
}
