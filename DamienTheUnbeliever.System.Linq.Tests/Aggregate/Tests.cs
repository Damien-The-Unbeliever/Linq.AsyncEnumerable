using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests.Aggregate
{
  public class Tests
  {
    [Theory]
    [MemberData(nameof(EarlyValidationCalls))]
    public void Eagerly_Validates(IAsyncEnumerable<int> source, Func<int, int, int> accumulator)
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = source.Aggregate(accumulator);
      });
    }

    [Theory]
    [MemberData(nameof(EmptyCalls))]
    public async Task Empty_Sequence_Throws(IAsyncEnumerable<int> source, Func<int, int, int> accumulator)
    {
      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        var iter = await source.Aggregate(accumulator);
      });
    }

    [Theory]
    [MemberData(nameof(FactorialCalls))]
    public async Task Aggregate_Can_Compute_Factorial_Plain(IAsyncEnumerable<int> source, Func<int, int, int> accumulator)
    {
      var actual = await source.Aggregate(accumulator);

      Assert.Equal(4 * 3 * 2, actual);
    }

    public static IEnumerable<object[]> EmptyCalls()
    {
      yield return new object[] { AsyncEnumerable.Empty<int>(), (Func<int, int, int>)((a, b) => a + b) };
    }

    public static IEnumerable<object[]> FactorialCalls()
    {
      yield return new object[] { AsyncEnumerable.Range(1,4), (Func<int, int, int>)((a, b) => a * b) };
    }

    public static IEnumerable<object[]> EarlyValidationCalls()
    {
      foreach(var item in EmptyCalls())
      {
        for (int i = 0; i < item.Length; i++)
        {
          var clone = (object[])item.Clone();
          clone[i] = null;
          yield return clone;
        }
      }
    }
  }
}
