using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class Join
  {
    [Theory]
    [MemberData(nameof(ValidationCalls))]
    public void Eager_Validation(Action action)
    {
      Assert.Throws<ArgumentNullException>(action);
    }
    [Fact]
    public async Task Multi_Join_With_Comparer_Value()
    {
      var first = Enumerable.Range(0, 8).AsAsyncEnumerable();
      var second = Enumerable.Range(8, 12).AsAsyncEnumerable();

      var actual = await first.Join(second, QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<(int,int)>((a, b)), new ModComparer()).ToList();

      Assert.Equal(24, actual.Count);
      Assert.Contains((5, 13), actual);
    }

    [Fact]
    public async Task Multi_Join_With_Comparer_Task()
    {
      var first = Enumerable.Range(0, 8).AsAsyncEnumerable();
      var second = Enumerable.Range(8, 12).AsAsyncEnumerable();

      var actual = await first.Join(second, QuickFunctions<int>.IdentityTasked, QuickFunctions<int>.IdentityTasked, (a, b) => Task.FromResult((a, b)), new ModComparer()).ToList();

      Assert.Equal(24, actual.Count);
      Assert.Contains((5, 13), actual);
    }

    [Fact]
    public async Task Multi_Join_With_No_Comparer_Value()
    {
      var first = Enumerable.Range(0, 8).AsAsyncEnumerable();
      var second = Enumerable.Range(4, 12).AsAsyncEnumerable();

      var actual = await first.Join(second, QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<(int, int)>((a, b))).ToList();

      Assert.Equal(4, actual.Count);
      Assert.Contains((5, 5), actual);
    }

    [Fact]
    public async Task Multi_Join_With_No_Comparer_Task()
    {
      var first = Enumerable.Range(0, 8).AsAsyncEnumerable();
      var second = Enumerable.Range(4, 12).AsAsyncEnumerable();

      var actual = await first.Join(second, QuickFunctions<int>.IdentityTasked, QuickFunctions<int>.IdentityTasked, (a, b) => Task.FromResult((a, b))).ToList();

      Assert.Equal(4, actual.Count);
      Assert.Contains((5, 5), actual);
    }

    public static IEnumerable<object[]> ValidationCalls()
    {
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(null,AsyncEnumerable.Empty<int>(),QuickFunctions<int>.IdentityTasked,QuickFunctions<int>.IdentityTasked,(a,b)=>Task.FromResult(a+b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(),null, QuickFunctions<int>.IdentityTasked, QuickFunctions<int>.IdentityTasked, (a, b) => Task.FromResult(a + b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), null, QuickFunctions<int>.IdentityTasked, (a, b) => Task.FromResult(a + b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityTasked, null, (a, b) => Task.FromResult(a + b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityTasked, QuickFunctions<int>.IdentityTasked, (Func<int,int,Task<int>>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(null, AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityTasked, QuickFunctions<int>.IdentityTasked, (a, b) => Task.FromResult(a + b),null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), null, QuickFunctions<int>.IdentityTasked, QuickFunctions<int>.IdentityTasked, (a, b) => Task.FromResult(a + b),null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), null, QuickFunctions<int>.IdentityTasked, (a, b) => Task.FromResult(a + b), null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityTasked, null, (a, b) => Task.FromResult(a + b), null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityTasked, QuickFunctions<int>.IdentityTasked, (Func<int, int, Task<int>>)null,null); }) };

      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(null, AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<int>(a + b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), null, QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<int>(a + b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), null, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<int>(a + b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityWrapped, null, (a, b) => new ValueTask<int>(a + b)); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (Func<int, int, ValueTask<int>>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(null, AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<int>(a + b), null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), null, QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<int>(a + b), null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), null, QuickFunctions<int>.IdentityWrapped, (a, b) => new ValueTask<int>(a + b), null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityWrapped, null, (a, b) => new ValueTask<int>(a + b), null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.Join(AsyncEnumerable.Empty<int>(), AsyncEnumerable.Empty<int>(), QuickFunctions<int>.IdentityWrapped, QuickFunctions<int>.IdentityWrapped, (Func<int, int, ValueTask<int>>)null, null); }) };

    }
  }
}
