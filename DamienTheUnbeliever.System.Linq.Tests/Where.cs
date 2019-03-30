using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Where
  {
    [Fact]
    public void Eagerly_Validates_Source_Plain_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where<bool>(null, a => a);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Plain_Predicate_Indexed()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where<bool>(null, (a,i) => a);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where<bool>(null, a => Task.FromResult(a));
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Predicate_Indexed()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where<bool>(null, (a, i) => Task.FromResult(a));
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where<bool>(null, a => new ValueTask<bool>(a));
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Predicate_Indexed()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where<bool>(null, (a, i) => new ValueTask<bool>(a));
      });
    }

    [Fact]
    public void Eagerly_Validates_Plain_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where(AsyncEnumerable.Empty<bool>(), (Func<bool,bool>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Plain_Predicate_Indexed()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where(AsyncEnumerable.Empty<bool>(), (Func<bool, int, bool>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Task_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where(AsyncEnumerable.Empty<bool>(), (Func<bool, Task<bool>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Task_Predicate_Indexed()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where(AsyncEnumerable.Empty<bool>(), (Func<bool, int, Task<bool>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_ValueTask_Predicate()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where(AsyncEnumerable.Empty<bool>(), (Func<bool, ValueTask<bool>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_ValueTask_Predicate_Indexed()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Where(AsyncEnumerable.Empty<bool>(), (Func<bool, int, ValueTask<bool>>)null);
      });
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_Plain_Predicate()
    {
      var source = AsyncEnumerable.Empty<int>();

      var actual = await source.Where(a => true).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_Plain_Predicate_Indexed()
    {
      var source = AsyncEnumerable.Empty<int>();

      var actual = await source.Where((a,i) => true).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_Task_Predicate()
    {
      var source = AsyncEnumerable.Empty<int>();

      var actual = await source.Where(a => Task.FromResult(true)).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_Task_Predicate_Indexed()
    {
      var source = AsyncEnumerable.Empty<int>();

      var actual = await source.Where((a, i) => Task.FromResult(true)).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_ValueTask_Predicate()
    {
      var source = AsyncEnumerable.Empty<int>();

      var actual = await source.Where(a => new ValueTask<bool>(true)).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Empty_Source_Yields_Empty_ValueTask_Predicate_Indexed()
    {
      var source = AsyncEnumerable.Empty<int>();

      var actual = await source.Where((a, i) => new ValueTask<bool>(true)).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task ValueTask_Predicate_Unindexed_Returns()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.Where(a => a < 3).ToList();

      Assert.Equal(6, actual.Count);
    }

    [Fact]
    public async Task ValueTask_Predicate_Indexed_Returns()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.Where((a,i) => a < 3&&i>10).ToList();

      Assert.Equal(3, actual.Count);
      Assert.Equal(2, actual[0]);
    }

    [Fact]
    public async Task Task_Predicate_Unindexed_Returns()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.Where(a => Task.FromResult(a < 3)).ToList();

      Assert.Equal(6, actual.Count);
    }

    [Fact]
    public async Task Task_Predicate_Indexed_Returns()
    {
      var source = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10).Reverse()).AsAsyncEnumerable();

      var actual = await source.Where((a, i) => Task.FromResult(a < 3 && i > 10)).ToList();

      Assert.Equal(3, actual.Count);
      Assert.Equal(2, actual[0]);
    }
  }
}
