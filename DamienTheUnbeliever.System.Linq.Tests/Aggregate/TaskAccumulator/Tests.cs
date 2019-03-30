using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests.Aggregate.TaskAccumulator
{
  public class Tests
  {
    [Theory]
    [MemberData(nameof(EarlyValidationCalls))]
    public void Eagerly_Validates(IAsyncEnumerable<int> source, Func<int, int, Task<int>> accumulator)
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var iter = source.Aggregate(accumulator);
      });
    }

    [Theory]
    [MemberData(nameof(EmptyCalls))]
    public async Task Empty_Sequence_Throws(IAsyncEnumerable<int> source, Func<int, int, Task<int>> accumulator)
    {
      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        var iter = await source.Aggregate(accumulator);
      });
    }

    [Theory]
    [MemberData(nameof(FactorialCalls))]
    public async Task Aggregate_Can_Compute_Factorial(IAsyncEnumerable<int> source, Func<int, int, Task<int>> accumulator)
    {
      var actual = await source.Aggregate(accumulator);

      Assert.Equal(4 * 3 * 2, actual);
    }

    public static IEnumerable<object[]> EmptyCalls()
    {
      foreach(var call in Aggregate.Tests.EmptyCalls())
      {
        call[1] = QuickFunctions.WrapTask((Func<int, int, int>)call[1]);
        yield return call;
      }
    }

    public static IEnumerable<object[]> FactorialCalls()
    {
      foreach (var call in Aggregate.Tests.FactorialCalls())
      {
        call[1] = QuickFunctions.WrapTask((Func<int, int, int>)call[1]);
        yield return call;
      }
    }
    public static IEnumerable<object[]> EarlyValidationCalls()
    {
      foreach (var item in EmptyCalls())
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
