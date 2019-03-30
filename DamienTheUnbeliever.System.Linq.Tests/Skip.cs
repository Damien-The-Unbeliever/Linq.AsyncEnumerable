using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Skip
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.Skip((IAsyncEnumerable<int>)null, 5);
      });
    }

    [Fact]
    public async Task Negative_Count_Doesnt_Skip()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable();

      var actual = await source.Skip(-5).ToList();

      Assert.Equal(10, actual.Count);
      Assert.Contains(0, actual);
      Assert.Contains(9, actual);
    }

    [Fact]
    public async Task Positive_Count_Consumes_Count_Plus_One_For_First()
    {
      var source = Enumerable.Range(0, 10).AsAsyncEnumerable().WithTracking();

      var actual = await source.Skip(4).First();

      Assert.Equal(4, actual);
      Assert.Equal(5, source.ItemsProvided);
      Assert.Equal(TrackingAsyncEnumerable<int>.Status.EnumerationComplete, source.State);
    }
  }
}
