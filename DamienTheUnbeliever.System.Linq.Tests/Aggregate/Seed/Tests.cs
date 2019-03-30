using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests.Aggregate.Seed
{
  public class Tests
  {
    [Theory]
    [MemberData(nameof(EarlyValidationCalls))]
    public void Eagerly_Validates(IAsyncEnumerable<int> source, Func<int, int, int> accumulator, int seed)
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = source.Aggregate(seed, accumulator);
      });
    }

    [Theory]
    [MemberData(nameof(EmptyCalls))]
    public async Task Empty_Sequence_Yields_Seed(IAsyncEnumerable<int> source, Func<int, int, int> accumulator, int seed)
    {
      var actual = await source.Aggregate(seed, accumulator);

      Assert.Equal(19, actual);
    }

    [Theory]
    [MemberData(nameof(FactorialCalls))]
    public async Task Computes_Factorial(IAsyncEnumerable<int> source, Func<int,int,int> accumulator, int seed)
    {
      var actual = await source.Aggregate(seed, accumulator);

      Assert.Equal(4 * 3 * 2 * 7, actual);
    }

    public static IEnumerable<object[]> FactorialCalls()
    {
      foreach (var item in Aggregate.Tests.FactorialCalls())
      {
        yield return item.Append(7).ToArray();
      }
    }

    public static IEnumerable<object[]> EmptyCalls()
    {
      foreach (var item in Aggregate.Tests.EmptyCalls())
      {
        yield return item.Append(19).ToArray();
      }
    }
    public static IEnumerable<object[]> EarlyValidationCalls()
    {
      foreach (var item in EmptyCalls())
      {
        for (int i = 0; i < item.Length-1; i++)
        {
          var clone = (object[])item.Clone();
          clone[i] = null;
          yield return clone;
        }
      }
    }
  }
}

