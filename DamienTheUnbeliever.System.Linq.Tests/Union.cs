using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Union
  {
    [Fact]
    public void Eagerly_Validates_First_NoComparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Union(null, AsyncEnumerable.Empty<int>());
      });
    }
    [Fact]
    public void Eagerly_Validates_Second_NoComparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Union(AsyncEnumerable.Empty<int>(),null);
      });
    }
    [Fact]
    public void Eagerly_Validates_First_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Union(null, AsyncEnumerable.Empty<int>(),new IntComparer());
      });
    }
    [Fact]
    public void Eagerly_Validates_Second_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Union(AsyncEnumerable.Empty<int>(),null, new IntComparer());
      });
    }

    [Fact]
    public async Task Iteration_Causes_Complete_Iteration_First_NoComparer()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable().WithTracking();
      var second = Enumerable.Range(5, 10).AsAsyncEnumerable().WithTracking();

      await using (var target = first.Union(second).GetAsyncEnumerator())
      {
        Assert.True(await target.MoveNextAsync());
        Assert.Equal(0, target.Current);
        Assert.Equal(1, first.ItemsProvided);
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.EnumeratorObtained, first.State);
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, second.State);
      }
    }

    [Fact]
    public async Task Iteration_Causes_Complete_Iteration_Second_Comparer()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable().WithTracking();
      var second = Enumerable.Range(5, 10).AsAsyncEnumerable().WithTracking();

      await using (var target = first.Union(second, new IntComparer()).GetAsyncEnumerator())
      {
        Assert.True(await target.MoveNextAsync());
        Assert.Equal(0, target.Current);
        Assert.Equal(1, first.ItemsProvided);
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.EnumeratorObtained, first.State);
        Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, second.State);
      }
    }

    [Fact]
    public async Task Empty_Second_Yields_First()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable();
      var second = AsyncEnumerable.Empty<int>();

      var target = await first.Union(second).ToList();

      Assert.Equal(10, target.Count);
    }

    [Fact]
    public async Task Non_Empty_Second_Yields_Smaller_Set()
    {
      var first = Enumerable.Range(0, 10).AsAsyncEnumerable();
      var second = Enumerable.Range(5,10).AsAsyncEnumerable();

      var target = await first.Union(second).ToList();

      Assert.Equal(15, target.Count);
      Assert.Contains(9, target);
      Assert.Contains(3, target);
      Assert.Contains(13, target);
    }
  }
}
