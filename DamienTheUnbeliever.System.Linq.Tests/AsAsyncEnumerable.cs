using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class AsAsyncEnumerable
  {
    #region API Argument Validation
    [Fact]
    public void PublicApi_Throws_InvalidSource_NoTasks_RetainUnspecified()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        AsyncEnumerable.AsAsyncEnumerable((IEnumerable<int>)null);
      });
    }
    [Fact]
    public void PublicApi_Throws_InvalidSource_Tasks_RetainUnspecified()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        AsyncEnumerable.AsAsyncEnumerable((IEnumerable<Task<int>>)null);
      });
    }

    [Fact]
    public void PublicApi_Throws_InvalidSource_TaskSelector_RetainUnspecified()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        AsyncEnumerable.AsAsyncEnumerable(null, QuickFunctions<Task<int>>.Identity);
      });
    }
    [Fact]
    public void PublicApi_Throws_InvalidSource_Tasks_Unordered()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        AsyncEnumerable.AsUnorderedAsyncEnumerable((IEnumerable<Task<int>>)null);
      });
    }

    [Fact]
    public void PublicApi_Throws_InvalidSource_TaskSelector_Unordered()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        AsyncEnumerable.AsUnorderedAsyncEnumerable(null, QuickFunctions<Task<int>>.Identity);
      });
    }
    [Fact]
    public void PublicApi_Throws_InvalidTaskSelector_RetainUnspecified()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        AsyncEnumerable.AsAsyncEnumerable(Enumerable.Empty<int>(),(Func<int,Task<int>>) null);
      });
    }

    [Fact]
    public void PublicApi_Throws_InvalidTaskSelector_Unordered()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        AsyncEnumerable.AsUnorderedAsyncEnumerable(Enumerable.Empty<int>(), (Func<int, Task<int>>)null);
      });
    }
    #endregion
    #region Order Retention
    [Fact]
    public async Task SlowTask_Still_Retains_Position()
    {
      var original = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await original.AsAsyncEnumerable().ToList();

      Assert.Equal(2, actual[actual.Count - 2]);
    }

    [Fact]
    public async Task SlowTask_At_End_When_Not_Retaining_Position()
    {
      var original = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

      var actual = await original.AsUnorderedAsyncEnumerable().ToList();

      Assert.Equal(2, actual[actual.Count - 1]);
    }
    [Fact]
    public async Task NonTasks_Retain_Position()
    {
      var expected = new List<int> { 1, 2, 3 };

      var actual = await expected.AsAsyncEnumerable().ToList();

      Assert.Equal(2, actual[actual.Count - 2]);
    }

    [Fact]
    public async Task SlowTask_Still_Retains_Position_WithSelector()
    {
      var original = new List<int> { 1, 2, 3 };

      var actual = await original.AsAsyncEnumerable(e=>Task.Delay(e==2?30:0).ContinueWith(_=>e)).ToList();

      Assert.Equal(2, actual[actual.Count - 2]);
    }

    [Fact]
    public async Task SlowTask_At_End_When_Not_Retaining_Position_WithSelector()
    {
      var original = new List<int> { 1, 2, 3 };

      var actual = await original.AsUnorderedAsyncEnumerable(e => Task.Delay(e == 2 ? 30 : 0).ContinueWith(_ => e)).ToList();

      Assert.Equal(2, actual[actual.Count - 1]);
    }
    #endregion
  }
}
