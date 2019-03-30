using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
	public static partial class AsyncEnumerable
	{
		#region API
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,TAccumulate> func,
			Func<TAccumulate,TResult> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal(source,new ValueTask<TAccumulate>(seed),QuickFunctions.WrapValueTask(func),a=>new ValueTask<TResult>(resultSelector(a)));
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TAccumulate> Aggregate<TSource,TAccumulate> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,TAccumulate> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,new ValueTask<TAccumulate>(seed),QuickFunctions.WrapValueTask(func),QuickFunctions<TAccumulate>.IdentityWrapped);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TSource> Aggregate<TSource> (
			this IAsyncEnumerable<TSource> source,
			Func<TSource,TSource,TSource> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,(a,b)=>new ValueTask<TSource>(func(a,b)));
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			ValueTask<TAccumulate> seed,
			Func<TAccumulate,TSource,TAccumulate> func,
			Func<TAccumulate,TResult> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal(source,seed,QuickFunctions.WrapValueTask(func),a=>new ValueTask<TResult>(resultSelector(a)));
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TAccumulate> Aggregate<TSource,TAccumulate> (
			this IAsyncEnumerable<TSource> source,
			ValueTask<TAccumulate> seed,
			Func<TAccumulate,TSource,TAccumulate> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,seed,QuickFunctions.WrapValueTask(func),QuickFunctions<TAccumulate>.IdentityWrapped);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TSource> Aggregate<TSource> (
			this IAsyncEnumerable<TSource> source,
			Func<TSource,TSource,ValueTask<TSource>> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,func);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,ValueTask<TAccumulate>> func,
			Func<TAccumulate,TResult> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal(source,new ValueTask<TAccumulate>(seed),func,a=>new ValueTask<TResult>(resultSelector(a)));
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TAccumulate> Aggregate<TSource,TAccumulate> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,ValueTask<TAccumulate>> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,new ValueTask<TAccumulate>(seed),func,QuickFunctions<TAccumulate>.IdentityWrapped);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,TAccumulate> func,
			Func<TAccumulate,ValueTask<TResult>> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal(source,new ValueTask<TAccumulate>(seed),QuickFunctions.WrapValueTask(func),resultSelector);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			ValueTask<TAccumulate> seed,
			Func<TAccumulate,TSource,ValueTask<TAccumulate>> func,
			Func<TAccumulate,TResult> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal(source,seed,func,a=>new ValueTask<TResult>(resultSelector(a)));
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TAccumulate> Aggregate<TSource,TAccumulate> (
			this IAsyncEnumerable<TSource> source,
			ValueTask<TAccumulate> seed,
			Func<TAccumulate,TSource,ValueTask<TAccumulate>> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,seed,func,QuickFunctions<TAccumulate>.IdentityWrapped);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,ValueTask<TAccumulate>> func,
			Func<TAccumulate,ValueTask<TResult>> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal(source,new ValueTask<TAccumulate>(seed),func,resultSelector);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			Task<TAccumulate> seed,
			Func<TAccumulate,TSource,Task<TAccumulate>> func,
			Func<TAccumulate,Task<TResult>> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(seed==null) throw new ArgumentNullException(nameof(seed));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal<TSource,TAccumulate,TResult>(source,seed,func,resultSelector);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TAccumulate> Aggregate<TSource,TAccumulate> (
			this IAsyncEnumerable<TSource> source,
			Task<TAccumulate> seed,
			Func<TAccumulate,TSource,Task<TAccumulate>> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(seed==null) throw new ArgumentNullException(nameof(seed));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal<TSource,TAccumulate,TAccumulate>(source,seed,func,QuickFunctions<TAccumulate>.IdentityTasked);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <param name="resultSelector">A transformation for the final result</param>
		/// <returns></returns>
		public static Task<TResult> Aggregate<TSource,TAccumulate,TResult> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,Task<TAccumulate>> func,
			Func<TAccumulate,Task<TResult>> resultSelector
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			if(resultSelector==null) throw new ArgumentNullException(nameof(resultSelector));
			return AggregateInternal(source,Task.FromResult(seed),func,resultSelector);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TAccumulate> Aggregate<TSource,TAccumulate> (
			this IAsyncEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate,TSource,Task<TAccumulate>> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,Task.FromResult(seed),func,QuickFunctions<TAccumulate>.IdentityTasked);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TSource> Aggregate<TSource> (
			this IAsyncEnumerable<TSource> source,
			Func<TSource,TSource,Task<TSource>> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal(source,func);
		}
		/// <summary>
		/// Computes an aggregate from a sequence
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the source sequence</typeparam>
		/// <typeparam name="TAccumulate">The type of aggregate to compute</typeparam>
		/// <param name="source">The original sequence</param>
		/// <param name="seed">An initial value for the aggregate</param>
		/// <param name="func">A function to compute a new value of the aggregate from its existing value and a new element from the source sequence</param>
		/// <returns></returns>
		public static Task<TAccumulate> Aggregate<TSource,TAccumulate> (
			this IAsyncEnumerable<TSource> source,
			Task<TAccumulate> seed,
			Func<TAccumulate,TSource,TAccumulate> func
		)
		{
			if(source==null) throw new ArgumentNullException(nameof(source));
			if(seed==null) throw new ArgumentNullException(nameof(seed));
			if(func==null) throw new ArgumentNullException(nameof(func));
			return AggregateInternal<TSource,TAccumulate,TAccumulate>(source,seed,QuickFunctions.WrapTask(func),QuickFunctions<TAccumulate>.IdentityTasked);
		}
		#endregion
	}
}

