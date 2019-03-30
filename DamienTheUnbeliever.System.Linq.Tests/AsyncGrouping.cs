using DamienTheUnbeliever.System.Linq.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class AsyncGrouping
  {
    [Fact]
    public async Task Completed_Grouping_Is_Enumerable()
    {
      var source = Enumerable.Range(0, 4).GetEnumerator();
      int callbackCount = 0;
      AsyncGrouping<int, int> target = null;
      target = new AsyncGrouping<int, int>(0, GetMore);

      await using(var iter = target.GetAsyncEnumerator())
      {
        Assert.Equal(0, callbackCount);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(1, callbackCount);
        Assert.Equal(0, iter.Current);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(2, callbackCount);
        Assert.Equal(1, iter.Current);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(3, callbackCount);
        Assert.Equal(2, iter.Current);
        Assert.True(await iter.MoveNextAsync());
        Assert.Equal(4, callbackCount);
        Assert.Equal(3, iter.Current);
        Assert.False(await iter.MoveNextAsync());
      }

      var second = await target.ToList();

      Assert.Equal(4, second.Count);
      Assert.Equal(5, callbackCount);

      async Task GetMore()
      {
        callbackCount++;
        if (source.MoveNext())
        {
          await target.AddElement(source.Current);
        }
        else
        {
          await target.MarkComplete();
        }
      }
    }
  }
}
