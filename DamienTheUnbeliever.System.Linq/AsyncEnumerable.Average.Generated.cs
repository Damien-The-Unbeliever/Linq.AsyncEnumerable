using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average(
			this IAsyncEnumerable<int> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<int>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<int>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<int>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, int> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<int>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average(
			this IAsyncEnumerable<int?> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<int?>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<int?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<int?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, int?> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<int?>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average(
			this IAsyncEnumerable<long> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<long>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<long>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<long>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, long> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<long>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average(
			this IAsyncEnumerable<long?> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<long?>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<long?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<long?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, long?> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<long?>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal> Average(
			this IAsyncEnumerable<decimal> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<decimal>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<decimal>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<decimal>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, decimal> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<decimal>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal?> Average(
			this IAsyncEnumerable<decimal?> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<decimal?>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<decimal?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<decimal?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<decimal?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, decimal?> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<decimal?>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float> Average(
			this IAsyncEnumerable<float> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<float>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<float>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<float>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, float> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<float>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float?> Average(
			this IAsyncEnumerable<float?> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<float?>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<float?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<float?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<float?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, float?> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<float?>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average(
			this IAsyncEnumerable<double> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<double>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<double>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<double>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, double> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<double>(selector(s)));
		}
		/// <summary>
		/// Computes the average value of values in a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average(
			this IAsyncEnumerable<double?> source
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return AverageInternal(source,QuickFunctions<double?>.IdentityWrapped);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, Task<double?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, ValueTask<double?>> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, selector);
		}
		/// <summary>
		/// Computes the average value of values selected from items in a sequence via a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to extract the values to averag</param>
		/// <returns>The average value of the elements</returns>
		public static Task<double?> Average<TSource>(
			this IAsyncEnumerable<TSource> source
			,Func<TSource, double?> selector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return AverageInternal(source, s=>new ValueTask<double?>(selector(s)));
		}
		
		#endregion
		#region Implementation
		private static async Task<double?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int?>> selector
		)
		{
			long count = 0;
			long? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return ((double)sum) / count;
			}
			return null;
		}
		private static async Task<double?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int?>> selector
		)
		{
			long count = 0;
			long? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return ((double)sum) / count;
			}
			return null;
		}
		private static async Task<double> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				long sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return ((double)sum) / count;
			}
		}
		private static async Task<double> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				long sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return ((double)sum) / count;
			}
		}
		private static async Task<double?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long?>> selector
		)
		{
			long count = 0;
			long? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (double)(sum / count);
			}
			return null;
		}
		private static async Task<double?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long?>> selector
		)
		{
			long count = 0;
			long? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (double)(sum / count);
			}
			return null;
		}
		private static async Task<double> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				long sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (double)(sum / count);
			}
		}
		private static async Task<double> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				long sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (double)(sum / count);
			}
		}
		private static async Task<decimal?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal?>> selector
		)
		{
			long count = 0;
			decimal? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (decimal)(sum / count);
			}
			return null;
		}
		private static async Task<decimal?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal?>> selector
		)
		{
			long count = 0;
			decimal? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (decimal)(sum / count);
			}
			return null;
		}
		private static async Task<decimal> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				decimal sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (decimal)(sum / count);
			}
		}
		private static async Task<decimal> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				decimal sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (decimal)(sum / count);
			}
		}
		private static async Task<float?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float?>> selector
		)
		{
			long count = 0;
			double? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (float)(sum / count);
			}
			return null;
		}
		private static async Task<float?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float?>> selector
		)
		{
			long count = 0;
			double? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (float)(sum / count);
			}
			return null;
		}
		private static async Task<float> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				double sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (float)(sum / count);
			}
		}
		private static async Task<float> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				double sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (float)(sum / count);
			}
		}
		private static async Task<double?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double?>> selector
		)
		{
			long count = 0;
			double? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (double)(sum / count);
			}
			return null;
		}
		private static async Task<double?> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double?>> selector
		)
		{
			long count = 0;
			double? sum = null;
			await foreach (var item in source)
			{
				var value = await selector(item);
				if (value.HasValue)
				{
					count++;
					sum = value.Value + (sum??0);
				}
			}
			if (count > 0&&sum.HasValue)
			{
				return (double)(sum / count);
			}
			return null;
		}
		private static async Task<double> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				double sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (double)(sum / count);
			}
		}
		private static async Task<double> AverageInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double>> selector
		)
		{
			await using(var iterator=source.GetAsyncEnumerator())
			{
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				long count = 1;
				double sum = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					count++;
					sum += await selector(iterator.Current);
				}
				return (double)(sum / count);
			}
		}
		
    #endregion
  }
}
