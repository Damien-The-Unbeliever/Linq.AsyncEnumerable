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
  namespace Generic
  {
    
    public class Min
    {
      [Fact]
      public void Eagerly_Validates_Source()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int>(null);
        });
      }
      [Fact]
      public void Eagerly_Validates_Source_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int,long>(null, a => (long)a);
        });
      }
      [Fact]
      public void Eagerly_Validates_Source_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int,long>(null, a => Task.FromResult((long)a));
        });
      }
      [Fact]
      public void Eagerly_Validates_Source_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int,long>(null, a => new ValueTask<long>((long)a));
        });
      }
      [Fact]
      public void Eagerly_Validates_Source_Comparer()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int>(null,new IntComparer());
        });
      }
      [Fact]
      public void Eagerly_Validates_Source_Plain_Selector_Comparer()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(null, a => ((long)a), new LongComparer());
        });
      }
      [Fact]
      public void Eagerly_Validates_Source_Task_Selector_Comparer()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(null, a => Task.FromResult((long)a), new LongComparer());
        });
      }
      [Fact]
      public void Eagerly_Validates_Source_ValueTask_Selector_Comparer()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(null, a => new ValueTask<long>((long)a), new LongComparer());
        });
      }
      [Fact]
      public void Eagerly_Validates_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(AsyncEnumerable.Empty<int>(), (Func<int,long>)null);
        });
      }
      [Fact]
      public void Eagerly_Validates_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(AsyncEnumerable.Empty<int>(), (Func<int, Task<long>>)null);
        });
      }
      [Fact]
      public void Eagerly_Validates_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<long>>)null);
        });
      }
      [Fact]
      public void Eagerly_Validates_Plain_Selector_Comparer()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(AsyncEnumerable.Empty<int>(), (Func<int, long>)null, new LongComparer());
        });
      }
      [Fact]
      public void Eagerly_Validates_Task_Selector_Comparer()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(AsyncEnumerable.Empty<int>(), (Func<int, Task<long>>)null, new LongComparer());
        });
      }
      [Fact]
      public void Eagerly_Validates_ValueTask_Selector_Comparer()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min<int, long>(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<long>>)null, new LongComparer());
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int>(target);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating_Plain_Selector()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int,int>(target,QuickFunctions<int>.Identity);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating_Task_Selector()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int, int>(target, QuickFunctions<int>.IdentityTasked);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating_ValueTask_Selector()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int, int>(target, QuickFunctions<int>.IdentityWrapped);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating_Comparer()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int>(target,new IntComparer());
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating_Plain_Selector_Comparer()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int, int>(target, QuickFunctions<int>.Identity, new IntComparer());
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating_Task_Selector_Comparer()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int, int>(target, QuickFunctions<int>.IdentityTasked, new IntComparer());
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iterating_ValueTask_Selector_Comparer()
      {
        var target = new ThrowingAsyncEnumerable<int>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await AsyncEnumerable.Min<int, int>(target, QuickFunctions<int>.IdentityWrapped, new IntComparer());
        });
      }
      [Fact]
      public async Task Empty_ValueType_Throws_Value_Selector()
      {
        var target = AsyncEnumerable.Empty<int>();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
          await AsyncEnumerable.Min<int>(target);
        });
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Default_Value_Selector()
      {
        var target = AsyncEnumerable.Empty<int?>();

        var actual = await AsyncEnumerable.Min<int?>(target);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Reference_Returns_Default_Value_Selector()
      {
        var target = AsyncEnumerable.Empty<string>();

        var actual = await AsyncEnumerable.Min<string>(target);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_ValueType_Throws_Task_Selector()
      {
        var target = AsyncEnumerable.Empty<int>();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
          await AsyncEnumerable.Min<int,int>(target,a=>Task.FromResult(a));
        });
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Default_Task_Selector()
      {
        var target = AsyncEnumerable.Empty<int?>();

        var actual = await AsyncEnumerable.Min<int?,int?>(target,a => Task.FromResult(a));

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Reference_Returns_Default_Task_Selector()
      {
        var target = AsyncEnumerable.Empty<string>();

        var actual = await AsyncEnumerable.Min<string,string>(target, a => Task.FromResult(a));

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Multi_Sequence_Returns_Value_Selector()
      {
        var target = Enumerable.Range(7, 4).AsAsyncEnumerable();

        var actual = await AsyncEnumerable.Min<int>(target);

        Assert.Equal(7, actual);
      }
      [Fact]
      public async Task Multi_Sequence_Returns_Task_Selector()
      {
        var target = Enumerable.Range(7, 4).AsAsyncEnumerable();

        var actual = await AsyncEnumerable.Min<int,int>(target,a=>Task.FromResult(a));

        Assert.Equal(7, actual);
      }
    }
  }
}
