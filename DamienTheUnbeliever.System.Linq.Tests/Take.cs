using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Take
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Take((IAsyncEnumerable<int>)null, 5);
      });
    }

    [Fact]
    public async Task Negative_Count_Doesnt_Take()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable();

      var actual = await source.Take(-5).ToList();

      Assert.Empty(actual);
    }

    [Fact]
    public async Task Positive_Count_Consumes_Count_Plus_One_For_First()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable().WithTracking();

      var actual = await source.Take(4).ToList();

      Assert.Equal(4, actual.Count);
      Assert.Equal(4, source.ItemsProvided);
      Assert.Equal(TrackingAsyncEnumerable<int>.Status.EnumerationComplete, source.State);
    }
  }
}
