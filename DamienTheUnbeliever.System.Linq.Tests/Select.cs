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
  
  public class Select
  {
    [Fact]
    public void Eagerly_Validates_Source_Plain_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(null, QuickFunctions<int>.Identity);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_Task_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(null, QuickFunctions<int>.IdentityTasked);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(null, QuickFunctions<int>.IdentityWrapped);
      });
    }
    [Fact]
    public void Eagerly_Validates_Plain_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(AsyncEnumerable.Empty<int>(), (Func<int,int>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Task_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(AsyncEnumerable.Empty<int>(), (Func<int, Task<int>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_ValueTask_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<int>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_Plain_Selector_Indexer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select<int,int>(null, (a,i)=>a);
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_Task_Selector_Indexer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select<int, int>(null, (a,i)=>Task.FromResult(a));
      });
    }
    [Fact]
    public void Eagerly_Validates_Source_ValueTask_Selector_Indexer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select<int, int>(null, (a,i)=>new ValueTask<int>(a));
      });
    }
    [Fact]
    public void Eagerly_Validates_Plain_Selector_Indexer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(AsyncEnumerable.Empty<int>(), (Func<int, int, int>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_Task_Selector_Indexer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(AsyncEnumerable.Empty<int>(), (Func<int, int, Task<int>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validates_ValueTask_Selector_Indexer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Select(AsyncEnumerable.Empty<int>(), (Func<int, int, ValueTask<int>>)null);
      });
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Plain_Selector()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await using(var iter = target.Select(a => a).GetAsyncEnumerator())
      {
        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await iter.MoveNextAsync();
        });
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Task_Selector()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await using (var iter = target.Select(a => Task.FromResult(a)).GetAsyncEnumerator())
      {
        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await iter.MoveNextAsync();
        });
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_ValueTask_Selector()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await using (var iter = target.Select(a => new ValueTask<int>(a)).GetAsyncEnumerator())
      {
        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await iter.MoveNextAsync();
        });
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Plain_Selector_Indexer()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await using (var iter = target.Select((a,i) => a).GetAsyncEnumerator())
      {
        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await iter.MoveNextAsync();
        });
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Task_Selector_Indexer()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await using (var iter = target.Select((a,i) => Task.FromResult(a)).GetAsyncEnumerator())
      {
        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await iter.MoveNextAsync();
        });
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_ValueTask_Selector_Indexer()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await using (var iter = target.Select((a,i) => new ValueTask<int>(a)).GetAsyncEnumerator())
      {
        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await iter.MoveNextAsync();
        });
      }
    }
    [Fact]
    public async Task Empty_Sequence_Yields_Empty_Sequence()
    {
      var target = AsyncEnumerable.Empty<int>();

      var actual = await target.Select(a => a * 2).ToList();

      Assert.Empty(actual);
    }
    [Fact]
    public async Task Empty_Sequence_Yields_Empty_Sequence_Task()
    {
      var target = AsyncEnumerable.Empty<int>();

      var actual = await target.Select(a => Task.FromResult(a * 2)).ToList();

      Assert.Empty(actual);
    }
    [Fact]
    public async Task Empty_Sequence_Yields_Empty_Sequence_Indexed()
    {
      var target = AsyncEnumerable.Empty<int>();

      var actual = await target.Select((a,i) => a * 2).ToList();

      Assert.Empty(actual);
    }
    [Fact]
    public async Task Empty_Sequence_Yields_Empty_Sequence_Task_Indexed()
    {
      var target = AsyncEnumerable.Empty<int>();

      var actual = await target.Select((a,i) => Task.FromResult(a * 2)).ToList();

      Assert.Empty(actual);
    }
    [Fact]
    public async Task Transforms_Input()
    {
      var target = Enumerable.Range(5, 2).AsAsyncEnumerable();

      var actual = await target.Select(a => a * 2).ToList();

      Assert.Equal(2, actual.Count);
      Assert.Contains(10, actual);
      Assert.Contains(12, actual);
    }
    [Fact]
    public async Task Transforms_Input_Task()
    {
      var target = Enumerable.Range(5, 2).AsAsyncEnumerable();

      var actual = await target.Select(a => Task.FromResult(a * 2)).ToList();

      Assert.Equal(2, actual.Count);
      Assert.Contains(10, actual);
      Assert.Contains(12, actual);
    }
    [Fact]
    public async Task Transforms_Input_Indexed()
    {
      var target = Enumerable.Range(5, 2).AsAsyncEnumerable();

      var actual = await target.Select((a,i) => i).ToList();

      Assert.Equal(2, actual.Count);
      Assert.Contains(0, actual);
      Assert.Contains(1, actual);
    }
    [Fact]
    public async Task Transforms_Input_Task_Indexed()
    {
      var target = Enumerable.Range(5, 2).AsAsyncEnumerable();

      var actual = await target.Select((a,i) => Task.FromResult(i)).ToList();

      Assert.Equal(2, actual.Count);
      Assert.Contains(0, actual);
      Assert.Contains(1, actual);
    }
  }
}
