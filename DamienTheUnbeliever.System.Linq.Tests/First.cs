using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class First
  {
    [Theory]
    [MemberData(nameof(ValidationCalls))]
    public void Eagerly_Validates_Source_No_Predicate(Action action)
    {
      Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public async Task Awaiting_Result_Iterates_Source()
    {
      var target = new ThrowingAsyncEnumerable<int>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.First();
      });
    }
    [Fact]
    public async Task Awaiting_Result_Iterates_Source_Plain_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.First(QuickFunctions<bool>.Identity);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Iterates_Source_Task_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.First(QuickFunctions<bool>.IdentityTasked);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Iterates_Source_ValueTask_Predicate()
    {
      var target = new ThrowingAsyncEnumerable<bool>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        await target.First(QuickFunctions<bool>.IdentityWrapped);
      });
    }

    [Theory]
    [MemberData(nameof(EmptyCalls))]
    public async Task Empty_Sequence_Throws(IAsyncEnumerable<long> source, object predicate)
    {
      if (predicate == null)
      {
        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
          await source.First();
        });
      }
      else
      {
        switch (predicate)
        {
          case Func<long, bool> typedPredicate:
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
              await source.First(typedPredicate);
            });
            break;
          case Func<long, Task<bool>> typedPredicate:
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
              await source.First(typedPredicate);
            });
            break;
          case Func<long, ValueTask<bool>> typedPredicate:
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
              await source.First(typedPredicate);
            });
            break;
        }
      }
    }

    public static IEnumerable<object[]> ValidationCalls()
    {
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.First<bool>(null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.First(null, QuickFunctions<bool>.Identity); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.First(null, QuickFunctions<bool>.IdentityWrapped); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.First(null, QuickFunctions<bool>.IdentityTasked); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.First(AsyncEnumerable.Empty<bool>(), (Func<bool, bool>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.First(AsyncEnumerable.Empty<bool>(), (Func<bool, Task<bool>>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.First(AsyncEnumerable.Empty<bool>(), (Func<bool, ValueTask<bool>>)null); }) };
    }

    public static IEnumerable<object[]> EmptyCalls()
    {
      yield return new object[] { AsyncEnumerable.Empty<long>(), null };
      yield return new object[] { AsyncEnumerable.Empty<long>(), (Func<long, bool>)(a=>true) };
      yield return new object[] { AsyncEnumerable.Empty<long>(), (Func<long, Task<bool>>)(a => Task.FromResult(true)) };
      yield return new object[] { AsyncEnumerable.Empty<long>(), (Func<long, ValueTask<bool>>)(a => new ValueTask<bool>(true)) };
    }

    [Fact]
    public async Task Singleton_Sequence_Returns()
    {
      var target = Enumerable.Repeat(19, 1).AsAsyncEnumerable();

      var actual = await target.First();

      Assert.Equal(19, actual);
    }
    [Fact]
    public async Task Multi_Sequence_Returns_ValueTask_Predicate()
    {
      var target = Enumerable.Range(18,9).AsAsyncEnumerable();

      var actual = await target.First(a=>a%2==1);

      Assert.Equal(19, actual);
    }
    [Fact]
    public async Task Multi_Sequence_Returns_Task_Predicate()
    {
      var target = Enumerable.Range(18, 3).AsAsyncEnumerable();

      var actual = await target.First(a => Task.FromResult(a % 2 == 1));

      Assert.Equal(19, actual);
    }
  }
}
