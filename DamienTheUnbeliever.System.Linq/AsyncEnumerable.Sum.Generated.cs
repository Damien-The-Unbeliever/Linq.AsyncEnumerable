using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum(
			this IAsyncEnumerable<int?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<int?>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, int?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<int?>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum(
			this IAsyncEnumerable<int> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<int>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, int> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<int>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<int> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum(
			this IAsyncEnumerable<long?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<long?>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, long?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<long?>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum(
			this IAsyncEnumerable<long> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<long>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, long> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<long>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<long> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum(
			this IAsyncEnumerable<decimal?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<decimal?>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, decimal?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<decimal?>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum(
			this IAsyncEnumerable<decimal> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<decimal>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, decimal> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<decimal>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<decimal> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum(
			this IAsyncEnumerable<float?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<float?>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, float?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<float?>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum(
			this IAsyncEnumerable<float> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<float>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, float> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<float>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<float> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum(
			this IAsyncEnumerable<double?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<double?>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, double?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<double?>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum(
			this IAsyncEnumerable<double> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return SumInternal(source, QuickFunctions<double>.IdentityWrapped);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, double> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, s => new ValueTask<double>(selector(s)));
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		/// <summary>
		/// Totals the values obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The total of values found in the sequence</returns>
		public static Task<double> Sum<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return SumInternal(source, selector);
		}
		#endregion
		#region Implementation
		private static async Task<int> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<int?>> selector)
		{
			int result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<int> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<int?>> selector)
		{
			int result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<int> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<int>> selector)
		{
			int result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<int> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<int>> selector)
		{
			int result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<long> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<long?>> selector)
		{
			long result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<long> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<long?>> selector)
		{
			long result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<long> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<long>> selector)
		{
			long result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<long> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<long>> selector)
		{
			long result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<decimal> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<decimal?>> selector)
		{
			decimal result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<decimal> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<decimal?>> selector)
		{
			decimal result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<decimal> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<decimal>> selector)
		{
			decimal result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<decimal> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<decimal>> selector)
		{
			decimal result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<float> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<float?>> selector)
		{
			float result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<float> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<float?>> selector)
		{
			float result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<float> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<float>> selector)
		{
			float result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<float> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<float>> selector)
		{
			float result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<double> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<double?>> selector)
		{
			double result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<double> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<double?>> selector)
		{
			double result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if(newValue.HasValue)
				{
					result += newValue.Value;
				}
			}
			return result;
		}
		private static async Task<double> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<double>> selector)
		{
			double result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
		private static async Task<double> SumInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<double>> selector)
		{
			double result = 0;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				result += newValue;
			}
			return result;
		}
    #endregion
  }
}
