using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests.Int
{

  using BaseType = global::System.Int32;

  public class Average
  {
    [Fact]
    public void Eagerly_Validate_Source_Nullable()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType?>());
      });
    }
    [Fact]
    public void Eagerly_Validate_Source()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType>());
      });
    }
    [Fact]
    public void Eagerly_Validate_Source_Nullable_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType?>(), QuickFunctions<BaseType?>.Identity);
      });
    }
    [Fact]
    public void Eagerly_Validate_Source_Selector()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType>(), QuickFunctions<BaseType>.Identity);
      });
    }
    [Fact]
    public void Eagerly_Validate_Source_Nullable_Selector_ValueTask()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType?>(), QuickFunctions<BaseType?>.IdentityWrapped);
      });
    }
    [Fact]
    public void Eagerly_Validate_Source_Selector_ValueTask()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType>(), QuickFunctions<BaseType>.IdentityWrapped);
      });
    }
    [Fact]
    public void Eagerly_Validate_Source_Nullable_Selector_Task()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType?>(), QuickFunctions<BaseType?>.IdentityTasked);
      });
    }
    [Fact]
    public void Eagerly_Validate_Source_Selector_Task()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(Null<BaseType>(), QuickFunctions<BaseType>.IdentityTasked);
      });
    }
    [Fact]
    public void Eagerly_Validate_Selector_Nullable_Selector()
    {
      var target = new ThrowingAsyncEnumerable<BaseType?>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(target, (Func<BaseType?, BaseType?>)null);
      });
    }
    [Fact]
    public void Eagerly_Validate_Selector_Selector()
    {
      var target = new ThrowingAsyncEnumerable<BaseType>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(target, (Func<BaseType, BaseType>)null);
      });
    }
    [Fact]
    public void Eagerly_Validate_Selector_Nullable_Selector_ValueTask()
    {
      var target = new ThrowingAsyncEnumerable<BaseType?>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(target, (Func<BaseType?, ValueTask<BaseType?>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validate_Selector_Selector_ValueTask()
    {
      var target = new ThrowingAsyncEnumerable<BaseType>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(target, (Func<BaseType, ValueTask<BaseType>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validate_Selector_Nullable_Selector_Task()
    {
      var target = new ThrowingAsyncEnumerable<BaseType?>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(target, (Func<BaseType?, Task<BaseType?>>)null);
      });
    }
    [Fact]
    public void Eagerly_Validate_Selector_Selector_Task()
    {
      var target = new ThrowingAsyncEnumerable<BaseType>();
      Assert.Throws<ArgumentNullException>(() =>
      {
        var t = AsyncEnumerable.Average(target, (Func<BaseType, Task<BaseType>>)null);
      });
    }

    [Fact]
    public async Task Awaiting_Result_Starts_Iteration()
    {
      var target = new ThrowingAsyncEnumerable<BaseType>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average();
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Nullable()
    {
      var target = new ThrowingAsyncEnumerable<BaseType?>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average();
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Selector()
    {
      var target = new ThrowingAsyncEnumerable<BaseType>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average(QuickFunctions<BaseType>.Identity);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Nullable_Selector()
    {
      var target = new ThrowingAsyncEnumerable<BaseType?>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average(QuickFunctions<BaseType?>.Identity);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Selector_Task()
    {
      var target = new ThrowingAsyncEnumerable<BaseType>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average(QuickFunctions<BaseType>.IdentityTasked);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Nullable_Selector_Task()
    {
      var target = new ThrowingAsyncEnumerable<BaseType?>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average(QuickFunctions<BaseType?>.IdentityTasked);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Selector_Value()
    {
      var target = new ThrowingAsyncEnumerable<BaseType>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average(QuickFunctions<BaseType>.IdentityWrapped);
      });
    }
    [Fact]
    public async Task Awaiting_Result_Starts_Iteration_Nullable_Selector_Value()
    {
      var target = new ThrowingAsyncEnumerable<BaseType?>();

      await Assert.ThrowsAsync<NotImplementedException>(async () =>
      {
        var iter = await target.Average(QuickFunctions<BaseType?>.IdentityWrapped);
      });
    }
    [Fact]
    public async Task Empty_Nullable_Returns_Null()
    {
      var target = AsyncEnumerable.Empty<BaseType?>();

      var result = await target.Average();

      Assert.Null(result);
    }
    [Fact]
    public async Task Empty_Nullable_Returns_Null_Tasked()
    {
      var target = AsyncEnumerable.Empty<BaseType?>();

      var result = await target.Average(QuickFunctions<BaseType?>.IdentityTasked);

      Assert.Null(result);
    }
    [Fact]
    public async Task Empty_Non_Nullable_Throws()
    {
      var target = AsyncEnumerable.Empty<BaseType>();

      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        var result = await target.Average();
      });
    }
    [Fact]
    public async Task Empty_Non_Nullable_Throws_Tasked()
    {
      var target = AsyncEnumerable.Empty<BaseType>();

      await Assert.ThrowsAsync<InvalidOperationException>(async () =>
      {
        var result = await target.Average(QuickFunctions<BaseType>.IdentityTasked);
      });
    }
    [Fact]
    public async Task Simple_Average_Not_Nullable()
    {
      var target = Enumerable.Range(1, 5).AsAsyncEnumerable();

      var actual = await target.Average();

      Assert.Equal(3, actual);
    }
    [Fact]
    public async Task Simple_Average_Nullable()
    {
      var target = Enumerable.Range(1, 5).AsAsyncEnumerable().Select(a => a % 2 == 0 ? (BaseType?)null : a);

      var actual = await target.Average();

      Assert.Equal(3, actual);
    }
    [Fact]
    public async Task Simple_Average_Not_Nullable_Tasked()
    {
      var target = Enumerable.Range(1, 5).AsAsyncEnumerable();

      var actual = await target.Average(a => Task.FromResult<BaseType>(a));

      Assert.Equal(3, actual);
    }
    [Fact]
    public async Task Simple_Average_Nullable_Tasked()
    {
      var target = Enumerable.Range(1, 5).AsAsyncEnumerable();

      var actual = await target.Average(a => Task.FromResult<BaseType?>(a % 2 == 0 ? (BaseType?)null : a));

      Assert.Equal(3, actual);
    }
    private IAsyncEnumerable<TSource> Null<TSource>()
    {
      return (IAsyncEnumerable<TSource>)null;
    }
  }
}

