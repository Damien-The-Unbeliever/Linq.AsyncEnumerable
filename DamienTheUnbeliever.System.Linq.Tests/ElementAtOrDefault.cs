using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class ElementAtOrDefault
  {
    [Fact]
    public void Eagerly_Validates_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = AsyncEnumerable.ElementAtOrDefault((IAsyncEnumerable<int>)null, 0);
      });
    }

    [Fact]
    public async Task Negative_Index_Returns_Default()
    {
      var source = Enumerable.Range(10, 10).AsAsyncEnumerable().WithTracking();

      var actual = await source.ElementAtOrDefault(-5);

      Assert.Equal(default, actual);
    }

    [Fact]
    public async Task Excess_Index_Returns_Default()
    {
      var source = Enumerable.Range(10, 10).AsAsyncEnumerable().WithTracking();

      var actual = await source.ElementAtOrDefault(25);

      Assert.Equal(default, actual);
    }

    [Fact]
    public async Task Can_Locate_Element()
    {
      var source = Enumerable.Range(10, 10).AsAsyncEnumerable();

      var actual = await source.ElementAtOrDefault(3);

      Assert.Equal(13, actual);
    }
  }
}
