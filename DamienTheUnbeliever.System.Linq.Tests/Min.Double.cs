using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  namespace Double
  {
    using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;
    using BaseType = global::System.Double;
    
    public class Min
    {
      [Fact]
      public void Non_Null_Eagerly_Validates_Source()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min((IAsyncEnumerable<BaseType>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min((IAsyncEnumerable<BaseType?>)null);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Source_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(null, QuickFunctions<BaseType>.Identity);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(null, QuickFunctions<BaseType?>.Identity);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Source_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(null, QuickFunctions<BaseType>.IdentityTasked);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(null, QuickFunctions<BaseType?>.IdentityTasked);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Source_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(null, QuickFunctions<BaseType>.IdentityWrapped);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Source_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(null, QuickFunctions<BaseType?>.IdentityWrapped);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(AsyncEnumerable.Empty<BaseType>(), (Func<BaseType,BaseType>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Plain_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(AsyncEnumerable.Empty<BaseType?>(), (Func<BaseType?, BaseType?>)null);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(AsyncEnumerable.Empty<BaseType>(), (Func<BaseType, Task<BaseType>>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_Task_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(AsyncEnumerable.Empty<BaseType?>(), (Func<BaseType?, Task<BaseType?>>)null);
        });
      }
      [Fact]
      public void Non_Null_Eagerly_Validates_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(AsyncEnumerable.Empty<BaseType>(), (Func<BaseType, ValueTask<BaseType>>)null);
        });
      }
      [Fact]
      public void Null_Eagerly_Validates_ValueTask_Selector()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Min(AsyncEnumerable.Empty<BaseType?>(), (Func<BaseType?, ValueTask<BaseType?>>)null);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min();
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Plain_Selector()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType>.Identity);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Task_Selector()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType>.IdentityTasked);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_ValueTask_Selector()
      {
        var target = new ThrowingAsyncEnumerable<BaseType>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType>.IdentityWrapped);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min();
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Plain_Selector_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType?>.Identity);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_Task_Selector_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType?>.IdentityTasked);
        });
      }
      [Fact]
      public async Task Awaiting_Result_Starts_Iteration_ValueTask_Selector_Nullable()
      {
        var target = new ThrowingAsyncEnumerable<BaseType?>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType?>.IdentityWrapped);
        });
      }

      [Fact]
      public async Task Empty_Nullable_Returns_Null()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Min();

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Throws()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
          await target.Min();
        });
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Null_Plain_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Min(QuickFunctions<BaseType?>.Identity);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Throws_Plain_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType>.Identity);
        });
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Null_Task_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Min(QuickFunctions<BaseType?>.IdentityTasked);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Throws_Task_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType>.IdentityTasked);
        });
      }
      [Fact]
      public async Task Empty_Nullable_Returns_Null_ValueTask_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType?>();

        var actual = await target.Min(QuickFunctions<BaseType?>.IdentityWrapped);

        Assert.Equal(default, actual);
      }
      [Fact]
      public async Task Empty_Non_Nullable_Throws_ValueTask_Selector()
      {
        var target = AsyncEnumerable.Empty<BaseType>();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
          await target.Min(QuickFunctions<BaseType>.IdentityWrapped);
        });
      }

      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Min();

        Assert.Equal((BaseType)19, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Min();

        Assert.Equal((BaseType?)19, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First_Plain_Selector()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Min(QuickFunctions<BaseType>.Identity);

        Assert.Equal((BaseType)19, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First_Plain_Selector()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Min(QuickFunctions<BaseType?>.Identity);

        Assert.Equal((BaseType?)19, actual);
      }
      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First_Task_Selector()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Min(QuickFunctions<BaseType>.IdentityTasked);

        Assert.Equal((BaseType)19, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First_Task_Selector()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Min(QuickFunctions<BaseType?>.IdentityTasked);

        Assert.Equal((BaseType?)19, actual);
      }
      [Fact]
      public async Task Multi_Sequence_Non_Nullable_Returns_First_ValueTask_Selector()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType)a).AsAsyncEnumerable();

        var actual = await target.Min(QuickFunctions<BaseType>.IdentityWrapped);

        Assert.Equal((BaseType)19, actual);
      }

      [Fact]
      public async Task Multi_Sequence_Nullable_Returns_First_ValueTask_Selector()
      {
        var target = Enumerable.Range(19, 8).Select(a => (BaseType?)a).AsAsyncEnumerable();

        var actual = await target.Min(QuickFunctions<BaseType?>.IdentityWrapped);

        Assert.Equal((BaseType?)19, actual);
      }
    }
  }
}
