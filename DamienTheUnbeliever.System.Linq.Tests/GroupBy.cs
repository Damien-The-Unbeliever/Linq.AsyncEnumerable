using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class GroupBy
  {
    [Theory]
    [MemberData(nameof(ValidationCalls))]
    public void Eager_Validation(Action action)
    {
      Assert.Throws<ArgumentNullException>(action);
    }

    public static IEnumerable<object[]> ValidationCalls()
    {
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity, QuickFunctions<int>.Identity); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, QuickFunctions<int>.Identity); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, QuickFunctions<int>.Identity, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, QuickResultSelector); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, QuickFunctions<int>.Identity, QuickResultSelector); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, QuickResultSelector, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, QuickFunctions<int>.Identity, QuickResultSelector, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null, QuickResultSelector); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null, QuickResultSelector); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null, QuickResultSelector, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, int>)null, QuickResultSelector, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity, QuickResultSelector); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, QuickResultSelector); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(null, QuickFunctions<int>.Identity, QuickResultSelector, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, QuickResultSelector, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy<int, int, int, int>(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy<int, int, int, int>(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, (Func<int, IAsyncEnumerable<int>, int>)null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy<int, int, int, int>(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, null, null); }) };
      yield return new object[] { (Action)(() => { var iter = AsyncEnumerable.GroupBy<int, int, int, int>(AsyncEnumerable.Empty<int>(), QuickFunctions<int>.Identity, QuickFunctions<int>.Identity, null, null); }) };
    }

    private static int QuickResultSelector(int key, IAsyncEnumerable<int> elements)
    {
      return key;
    }

    private static long LongResultSelector(long key, IAsyncEnumerable<long> elements)
    {
      return key;
    }

    public static IEnumerable<object[]> EmptyCalls()
    {
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.Identity, null, null };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityTasked, null, null };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityWrapped, null, null };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.Identity, QuickFunctions<long>.Identity, null };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityTasked, QuickFunctions<long>.IdentityTasked, null };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityWrapped, QuickFunctions<long>.IdentityWrapped, null };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.Identity, null,(Func<long,IAsyncEnumerable<long>,long>) LongResultSelector };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityTasked, null, QuickFunctions.WrapTask<long,IAsyncEnumerable<long>,long>(LongResultSelector) };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityWrapped, null, QuickFunctions.WrapValueTask<long, IAsyncEnumerable<long>, long>(LongResultSelector) };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.Identity, QuickFunctions<long>.Identity, (Func<long, IAsyncEnumerable<long>, long>)LongResultSelector };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityTasked, QuickFunctions<long>.IdentityTasked, QuickFunctions.WrapTask<long, IAsyncEnumerable<long>, long>(LongResultSelector) };
      yield return new object[] { AsyncEnumerable.Empty<long>(), QuickFunctions<long>.IdentityWrapped, QuickFunctions<long>.IdentityWrapped, QuickFunctions.WrapValueTask<long, IAsyncEnumerable<long>, long>(LongResultSelector) };
    }

    [Theory]
    [MemberData(nameof(EmptyCalls))]
    public async Task Empty_Sequence_Throws(IAsyncEnumerable<long> source, dynamic keySelector, dynamic elementSelector, dynamic resultSelector)
    {
      int cnt;
      if (elementSelector == null && resultSelector == null)
      {
        cnt = await AsyncEnumerable.Count(AsyncEnumerable.GroupBy<long, long>(source, keySelector));
      }
      else
      {
        if (elementSelector != null && resultSelector == null)
        {
          cnt = await AsyncEnumerable.Count(AsyncEnumerable.GroupBy<long, long, long>(source, keySelector, elementSelector));
        }
        else if (elementSelector != null && resultSelector != null)
        {
          cnt = await AsyncEnumerable.Count(AsyncEnumerable.GroupBy<long, long, long, long>(source, keySelector, elementSelector, resultSelector));
        }
        else
        {
          cnt = await AsyncEnumerable.Count(AsyncEnumerable.GroupBy<long, long, long>(source, keySelector, resultSelector));
        }
      }

      Assert.Equal(0, cnt);
    }
  }
}