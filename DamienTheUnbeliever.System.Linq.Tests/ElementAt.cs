using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class ElementAt
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.ElementAt((IAsyncEnumerable<int>)null, 0);
      });
    }

    [Fact]
    public async Task Negative_Index_Does_Not_Iterate()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable().WithTracking();

      await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
      {
        await source.ElementAt(-5);
      });

      Assert.Equal(TrackingAsyncEnumerable<int>.Status.Initial, source.State);
    }

    [Fact]
    public async Task Excess_Index_Throws()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable().WithTracking();

      await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
      {
        await source.ElementAt(25);
      });

      Assert.Equal(TrackingAsyncEnumerable<int>.Status.EnumerationComplete, source.State);
    }

    [Fact]
    public async Task Can_Locate_Element()
    {
      var source = Enumerable.Range(10, 10).AsAsyncEnumerable();

      var actual = await source.ElementAt(3);

      Assert.Equal(13, actual);
    }
  }
}
