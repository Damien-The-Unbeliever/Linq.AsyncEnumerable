using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class SelectMany
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          Repeater());
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_WithIndexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          RepeaterWithIndexing());
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int,IAsyncEnumerable<int>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector_WithIndexing()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int, int, IAsyncEnumerable<int>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_With_Plain_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          Repeater(),
          PassThrough());
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_WithIndexing_And_Plain_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          RepeaterWithIndexing(),
          PassThrough());
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector_With_Plain_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int, IAsyncEnumerable<int>>)null,
          PassThrough());
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector_WithIndexing_And_Plain_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int, int, IAsyncEnumerable<int>>)null,
          PassThrough());
      });
    }

    [Fact]
    public void Eagerly_Validates_Results_With_Plain_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          Repeater(),
          (Func<int, int, int>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Results_WithIndexing_And_Plain_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          RepeaterWithIndexing(),
          (Func<int, int, int>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_With_Task_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          Repeater(),
          PassThroughTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_WithIndexing_And_Task_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          RepeaterWithIndexing(),
          PassThroughTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector_With_Task_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int, IAsyncEnumerable<int>>)null,
          PassThroughTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector_WithIndexing_And_Task_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int, int, IAsyncEnumerable<int>>)null,
          PassThroughTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Results_With_Task_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          Repeater(),
          (Func<int, int, Task<int>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Results_WithIndexing_And_Task_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          RepeaterWithIndexing(),
          (Func<int, int, Task<int>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_With_ValueTask_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          Repeater(),
          PassThroughValueTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Source_WithIndexing_And_ValueTask_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          (IAsyncEnumerable<int>)null,
          RepeaterWithIndexing(),
          PassThroughValueTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector_With_ValueTask_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int, IAsyncEnumerable<int>>)null,
          PassThroughValueTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Selector_WithIndexing_And_ValueTask_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          (Func<int, int, IAsyncEnumerable<int>>)null,
          PassThroughValueTask());
      });
    }

    [Fact]
    public void Eagerly_Validates_Results_With_ValueTask_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          Repeater(),
          (Func<int, int, ValueTask<int>>)null);
      });
    }

    [Fact]
    public void Eagerly_Validates_Results_WithIndexing_And_ValueTask_Results()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.SelectMany(
          AsyncEnumerable.Empty<int>(),
          RepeaterWithIndexing(),
          (Func<int, int, ValueTask<int>>)null);
      });
    }

    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(Repeater()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once_Indexed()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(RepeaterWithIndexing()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }

    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once_Plain_Selector()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(Repeater(),PassThrough()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once_Indexed_Plain_Selector()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(RepeaterWithIndexing(),PassThrough()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }

    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once_Task_Selector()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(Repeater(), PassThroughTask()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once_Indexed_Task_Selector()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(RepeaterWithIndexing(), PassThroughTask()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }

    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once_ValueTask_Selector()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(Repeater(), PassThroughValueTask()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }
    [Fact]
    public async Task Starting_Iteration_Iterates_Source_Once_Indexed_ValueTask_Selector()
    {
      var source = Enumerable.Range(1, 4).AsAsyncEnumerable().WithTracking();

      await using (var iter = source.SelectMany(RepeaterWithIndexing(), PassThroughValueTask()).GetAsyncEnumerator())
      {
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, source.ItemsProvided);
      }
    }

    private static Func<int, int, int> PassThrough()
    {
      return (src, col) => col;
    }

    private static Func<int, int, Task<int>> PassThroughTask()
    {
      return (src, col) => Task.FromResult(col);
    }

    private static Func<int, int, ValueTask<int>> PassThroughValueTask()
    {
      return (src, col) => new ValueTask<int>(col);
    }

    private static Func<int, int, IAsyncEnumerable<int>> RepeaterWithIndexing()
    {
      return (a, i) => Enumerable.Repeat(a, a).AsAsyncEnumerable();
    }

    private static Func<int, IAsyncEnumerable<int>> Repeater()
    {
      return a => Enumerable.Repeat(a, a).AsAsyncEnumerable();
    }
  }
}
