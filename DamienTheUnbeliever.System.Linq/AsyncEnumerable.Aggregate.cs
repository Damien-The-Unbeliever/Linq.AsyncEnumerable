using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region Implementation
    private static async Task<TResult> AggregateInternal<TSource, TAccumulate, TResult>(
      this IAsyncEnumerable<TSource> source,
      Task<TAccumulate> seed,
      Func<TAccumulate, TSource, Task<TAccumulate>> func,
      Func<TAccumulate, Task<TResult>> resultSelector
    )
    {
      var agg = await seed;
      await foreach(var item in source)
      {
        agg = await func(agg, item);
      }
      return await (resultSelector(agg));
    }

    private static async Task<TSource> AggregateInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TSource, Task<TSource>> func
    )
    {
      await using(var iter = source.GetAsyncEnumerator())
      {
        if (!await iter.MoveNextAsync()) throw new InvalidOperationException(NoElement);
        var agg = iter.Current;

        while(await iter.MoveNextAsync())
        {
          agg = await func(agg, iter.Current);
        }
        return agg;
      }
    }
    private static async Task<TResult> AggregateInternal<TSource, TAccumulate, TResult>(
      this IAsyncEnumerable<TSource> source,
      ValueTask<TAccumulate> seed,
      Func<TAccumulate, TSource, ValueTask<TAccumulate>> func,
      Func<TAccumulate, ValueTask<TResult>> resultSelector
    )
    {
      var agg = await seed;
      await foreach (var item in source)
      {
        agg = await func(agg, item);
      }
      return await (resultSelector(agg));
    }

    private static async Task<TSource> AggregateInternal<TSource>(
      this IAsyncEnumerable<TSource> source,
      Func<TSource, TSource, ValueTask<TSource>> func
    )
    {
      await using (var iter = source.GetAsyncEnumerator())
      {
        if (!await iter.MoveNextAsync()) throw new InvalidOperationException(NoElement);
        var agg = iter.Current;

        while (await iter.MoveNextAsync())
        {
          agg = await func(agg, iter.Current);
        }
        return agg;
      }
    }
    #endregion
  }
}
