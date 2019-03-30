﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using static DamienTheUnbeliever.System.Linq.AsyncEnumerable;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  namespace Value
  {
    public class All
    {
      private readonly Func<bool, ValueTask<bool>> identityPredicate = QuickFunctions<bool>.IdentityWrapped;
      private readonly Func<bool, ValueTask<bool>> nullPredicate = null;
      private readonly Func<int, ValueTask<bool>> greaterZeroPredicate = a => new ValueTask<bool>(a > 0);
      private readonly Func<int, ValueTask<bool>> lessThen3Predicate = a => new ValueTask<bool>(a < 3);
      [Fact]
      public void Eager_Validation_Source()
      {
        var target = new ThrowingAsyncEnumerable<bool>();

        Assert.Throws<ArgumentNullException>(() =>
        {

          var noIterate = AsyncEnumerable.All(null, identityPredicate);
        });
      }

      [Fact]
      public void Eager_Validation_Predicate()
      {
        var target = new ThrowingAsyncEnumerable<bool>();

        Assert.Throws<ArgumentNullException>(() =>
        {
          var noIterate = AsyncEnumerable.All(target, nullPredicate);
        });
      }

      [Fact]
      public async Task Awaiting_Task_Forces_Iteration()
      {
        var target = new ThrowingAsyncEnumerable<bool>();

        await Assert.ThrowsAsync<NotImplementedException>(async () =>
        {
          var all = await target.All(identityPredicate);
        });
      }

      [Fact]
      public async Task CanAnswer_True()
      {
        var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));

  
        var actual = await target.AsAsyncEnumerable().All(greaterZeroPredicate);

        Assert.True(actual);
      }
      [Fact]
      public async Task CanAnswer_False()
      {
        var target = new TasksWithDelays<int>((1, 0), (2, 30), (3, 0));


        var actual = await target.AsAsyncEnumerable().All(lessThen3Predicate);

        Assert.False(actual);
      }
    }
  }
}
