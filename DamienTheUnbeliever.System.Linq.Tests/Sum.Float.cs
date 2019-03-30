using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  namespace Float
  {
    using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;
    using BaseType = global::System.Single;
    
    public class Sum
    {
      [Fact]
      public void Non_Null_Eagerly_Validates_Source()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum((IAsyncEnumerable<BaseType>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum((IAsyncEnumerable<BaseType?>)null);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Source_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(null, QuickFunctions<BaseType>.Identity);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(null, QuickFunctions<BaseType?>.Identity);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Source_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(null, QuickFunctions<BaseType>.IdentityTasked);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(null, QuickFunctions<BaseType?>.IdentityTasked);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Source_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(null, QuickFunctions<BaseType>.IdentityWrapped);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(null, QuickFunctions<BaseType?>.IdentityWrapped);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(AsyncEnumerable.Empty<BaseType>(), (Func<BaseType,BaseType>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(AsyncEnumerable.Empty<BaseType?>(), (Func<BaseType?, BaseType?>)null);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(AsyncEnumerable.Empty<BaseType>(), (Func<BaseType, Task<BaseType>>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(AsyncEnumerable.Empty<BaseType?>(), (Func<BaseType?, Task<BaseType?>>)null);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(AsyncEnumerable.Empty<BaseType>(), (Func<BaseType, ValueTask<BaseType>>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Sum(AsyncEnumerable.Empty<BaseType?>(), (Func<BaseType?, ValueTask<BaseType?>>)null);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum();
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Plain_Selector()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum(QuickFunctions<BaseType>.Identity);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Task_Selector()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum(QuickFunctions<BaseType>.IdentityTasked);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_ValueTask_Selector()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum(QuickFunctions<BaseType>.IdentityWrapped);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum();
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Plain_Selector_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum(QuickFunctions<BaseType?>.Identity);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Task_Selector_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum(QuickFunctions<BaseType?>.IdentityTasked);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_ValueTask_Selector_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Sum(QuickFunctions<BaseType?>.IdentityWrapped);
        });
      }

      [Fact]
      public async Task Empty_Nullable_Returns_Null()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Sum();

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Returns_Zero()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        var actual = await target.Sum();

        Assert.Equal(0, actual);
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Null_Plain_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Sum(QuickFunctions<BaseType?>.Identity);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Returns_Zero_Plain_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        var actual = await target.Sum(QuickFunctions<BaseType>.Identity);

        Assert.Equal(0, actual);
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Null_Task_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Sum(QuickFunctions<BaseType?>.IdentityTasked);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Returns_Zero_Task_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        var actual = await target.Sum(QuickFunctions<BaseType>.IdentityTasked);

        Assert.Equal(0, actual);
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Null_ValueTask_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Sum(QuickFunctions<BaseType?>.IdentityWrapped);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Returns_Zero_ValueTask_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        var actual = await target.Sum(QuickFunctions<BaseType>.IdentityWrapped);

        Assert.Equal(0, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Sum();

        Assert.Equal((BaseType)28, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Sum();

        Assert.Equal((BaseType?)28, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First_Plain_Selector()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Sum(QuickFunctions<BaseType>.Identity);

        Assert.Equal((BaseType)28, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First_Plain_Selector()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Sum(QuickFunctions<BaseType?>.Identity);

        Assert.Equal((BaseType?)28, actual);
      }
      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First_Task_Selector()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Sum(QuickFunctions<BaseType>.IdentityTasked);

        Assert.Equal((BaseType)28, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First_Task_Selector()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Sum(QuickFunctions<BaseType?>.IdentityTasked);

        Assert.Equal((BaseType?)28, actual);
      }
      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First_ValueTask_Selector()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Sum(QuickFunctions<BaseType>.IdentityWrapped);

        Assert.Equal((BaseType)28, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First_ValueTask_Selector()
      {
        var target = Enumerable.Range(0, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Sum(QuickFunctions<BaseType?>.IdentityWrapped);

        Assert.Equal((BaseType?)28, actual);
      }
    }
  }
}
