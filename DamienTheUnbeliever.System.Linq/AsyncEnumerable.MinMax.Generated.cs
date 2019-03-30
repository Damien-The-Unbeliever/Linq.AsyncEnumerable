using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<int?> Min(
			this IAsyncEnumerable<int?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<int?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<int?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, int?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<int?>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<int?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<int?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Min(
			this IAsyncEnumerable<int> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<int>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, int> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<int>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<int?> Max(
			this IAsyncEnumerable<int?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<int?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<int?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, int?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<int?>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<int?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<int?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Max(
			this IAsyncEnumerable<int> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<int>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, int> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<int>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<int> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<long?> Min(
			this IAsyncEnumerable<long?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<long?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<long?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, long?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<long?>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<long?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<long?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Min(
			this IAsyncEnumerable<long> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<long>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, long> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<long>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<long?> Max(
			this IAsyncEnumerable<long?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<long?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<long?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, long?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<long?>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<long?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<long?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Max(
			this IAsyncEnumerable<long> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<long>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, long> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<long>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<long> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<decimal?> Min(
			this IAsyncEnumerable<decimal?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<decimal?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<decimal?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, decimal?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<decimal?>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<decimal?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<decimal?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Min(
			this IAsyncEnumerable<decimal> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<decimal>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, decimal> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<decimal>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<decimal?> Max(
			this IAsyncEnumerable<decimal?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<decimal?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<decimal?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, decimal?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<decimal?>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<decimal?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<decimal?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Max(
			this IAsyncEnumerable<decimal> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<decimal>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, decimal> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<decimal>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<decimal> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<float?> Min(
			this IAsyncEnumerable<float?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<float?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<float?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, float?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<float?>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<float?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<float?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Min(
			this IAsyncEnumerable<float> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<float>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, float> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<float>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<float?> Max(
			this IAsyncEnumerable<float?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<float?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<float?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, float?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<float?>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<float?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<float?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Max(
			this IAsyncEnumerable<float> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<float>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, float> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<float>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<float> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<double?> Min(
			this IAsyncEnumerable<double?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<double?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<double?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, double?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<double?>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<double?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		public static Task<double?> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Min(
			this IAsyncEnumerable<double> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MinInternal(source, QuickFunctions<double>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, double> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, s => new ValueTask<double>(selector(s)));
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the lowest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The lowest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Min<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MinInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<double?> Max(
			this IAsyncEnumerable<double?> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<double?>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<double?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, double?> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<double?>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<double?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		public static Task<double?> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double?>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained from a sequence
		/// </summary>
		/// <param name="source">The sequence of elements</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Max(
			this IAsyncEnumerable<double> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return MaxInternal(source, QuickFunctions<double>.IdentityWrapped);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, double> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, s => new ValueTask<double>(selector(s)));
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		/// <summary>
		/// Locates the highest value obtained by transforming a sequence with a <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="selector">The selector to transform the results</param>
		/// <returns>The highest value found in the sequence</returns>
		/// <exception cref="InvalidOperationException">The sequence contains no elements</exception>
		public static Task<double> Max<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double>> selector)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			return MaxInternal(source, selector);
		}
		#endregion
		#region Implementation
		private static async Task<int?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<int?>> selector)
		{
			int? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<int?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<int?>> selector)
		{
			int? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<int> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				int result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<int> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				int result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<int?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<int?>> selector)
		{
			int? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<int?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<int?>> selector)
		{
			int? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<int> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<int>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				int result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<int> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<int>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				int result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<long?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<long?>> selector)
		{
			long? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<long?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<long?>> selector)
		{
			long? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<long> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				long result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<long> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				long result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<long?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<long?>> selector)
		{
			long? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<long?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<long?>> selector)
		{
			long? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<long> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<long>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				long result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<long> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<long>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				long result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<decimal?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<decimal?>> selector)
		{
			decimal? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<decimal?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<decimal?>> selector)
		{
			decimal? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<decimal> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				decimal result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<decimal> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				decimal result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<decimal?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<decimal?>> selector)
		{
			decimal? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<decimal?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<decimal?>> selector)
		{
			decimal? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<decimal> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<decimal>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				decimal result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<decimal> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<decimal>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				decimal result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<float?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<float?>> selector)
		{
			float? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<float?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<float?>> selector)
		{
			float? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<float> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				float result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<float> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				float result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<float?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<float?>> selector)
		{
			float? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<float?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<float?>> selector)
		{
			float? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<float> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<float>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				float result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<float> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<float>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				float result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<double?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<double?>> selector)
		{
			double? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<double?> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<double?>> selector)
		{
			double? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result > newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<double> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				double result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<double> MinInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				double result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result > newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<double?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,Task<double?>> selector)
		{
			double? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<double?> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource,ValueTask<double?>> selector)
		{
			double? result = null;
			await foreach(var item in source)
			{
				var newValue = await selector(item);
				if (item != null && (result == null || result < newValue))
				{
					result = newValue;
				}
			}
			return result;
		}
		private static async Task<double> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<double>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				double result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
		private static async Task<double> MaxInternal<TSource>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<double>> selector)
		{
			await using(var iterator = source.GetAsyncEnumerator())
			{
				double result = default;
				if(!await iterator.MoveNextAsync())
				{
					throw new InvalidOperationException(NoElement);
				}
				result = await selector(iterator.Current);
				while(await iterator.MoveNextAsync())
				{
					var newValue = await selector(iterator.Current);
					if(result < newValue)
					{
						result = newValue;
					}
				}
				return result;
			}
		}
    #endregion
  }
}
