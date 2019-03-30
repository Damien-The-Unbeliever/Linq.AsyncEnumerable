using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class OrderBy
  {
    [Fact]
    public async Task Simple_Sorting()
    {
      var source = AsyncEnumerable.Range(10, 10).Concat(AsyncEnumerable.Range(0, 10));

      var results = await source.OrderBy(a => Task.FromResult(a), null).ToList();

      Assert.Equal(20, results.Count);
      Assert.Equal(0, results[0]);
    }

    [Fact]
    public async Task Simple_Sorting_Descending()
    {
      var source = AsyncEnumerable.Range(10, 10).Concat(AsyncEnumerable.Range(0, 10));

      var results = await source.OrderByDescending(a => Task.FromResult(a), null).ToList();

      Assert.Equal(20, results.Count);
      Assert.Equal(19, results[0]);
    }
  }
}
