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
		/// Form groups of elements using a key selector.Transform each element.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
			,Func<TSource, TElement> elementSelector
			,Func<TKey, IAsyncEnumerable<TElement>, TResult> resultSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions.WrapValueTask(elementSelector), QuickFunctions.WrapValueTask(resultSelector), comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
			,Func<TSource, Task<TElement>> elementSelector
			,Func<TKey, IAsyncEnumerable<TElement>, Task<TResult>> resultSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, elementSelector, resultSelector, comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
			,Func<TSource, ValueTask<TElement>> elementSelector
			,Func<TKey, IAsyncEnumerable<TElement>, ValueTask<TResult>> resultSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, elementSelector, resultSelector, comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
			,Func<TSource, TElement> elementSelector
			,Func<TKey, IAsyncEnumerable<TElement>, TResult> resultSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions.WrapValueTask(elementSelector), QuickFunctions.WrapValueTask(resultSelector), null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
			,Func<TSource, Task<TElement>> elementSelector
			,Func<TKey, IAsyncEnumerable<TElement>, Task<TResult>> resultSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, elementSelector, resultSelector, null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
			,Func<TSource, ValueTask<TElement>> elementSelector
			,Func<TKey, IAsyncEnumerable<TElement>, ValueTask<TResult>> resultSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, elementSelector, resultSelector, null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TElement>> GroupBy<TSource, TKey, TElement>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
			,Func<TSource, TElement> elementSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions.WrapValueTask(elementSelector), comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TElement>> GroupBy<TSource, TKey, TElement>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
			,Func<TSource, Task<TElement>> elementSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			return GroupByInternal(source, keySelector, elementSelector, comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TElement>> GroupBy<TSource, TKey, TElement>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
			,Func<TSource, ValueTask<TElement>> elementSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			return GroupByInternal(source, keySelector, elementSelector, comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TElement>> GroupBy<TSource, TKey, TElement>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
			,Func<TSource, TElement> elementSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions.WrapValueTask(elementSelector), null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TElement>> GroupBy<TSource, TKey, TElement>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
			,Func<TSource, Task<TElement>> elementSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			return GroupByInternal(source, keySelector, elementSelector, null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Transform each element.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TElement">The type into which each element of the sequence is transformed</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="elementSelector">The transformation to apply to individual elements</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TElement>> GroupBy<TSource, TKey, TElement>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
			,Func<TSource, ValueTask<TElement>> elementSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			return GroupByInternal(source, keySelector, elementSelector, null);
		}
		
		/// <summary>
		/// Form groups of elements using a key selector.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
			,Func<TKey, IAsyncEnumerable<TSource>, TResult> resultSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions<TSource>.IdentityWrapped,QuickFunctions.WrapValueTask(resultSelector), comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
			,Func<TKey, IAsyncEnumerable<TSource>, Task<TResult>> resultSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityTasked,resultSelector, comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
			,Func<TKey, IAsyncEnumerable<TSource>, ValueTask<TResult>> resultSelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityWrapped,resultSelector, comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
			,Func<TKey, IAsyncEnumerable<TSource>, TResult> resultSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions<TSource>.IdentityWrapped,QuickFunctions.WrapValueTask(resultSelector), null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
			,Func<TKey, IAsyncEnumerable<TSource>, Task<TResult>> resultSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityTasked,resultSelector, null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.Combine the elements into a result.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <typeparam name="TResult">The type of the final result</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="resultSelector">The function to reduce the transformed elements into a final result</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
			,Func<TKey, IAsyncEnumerable<TSource>, ValueTask<TResult>> resultSelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityWrapped,resultSelector, null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TSource>> GroupBy<TSource, TKey>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions<TSource>.IdentityWrapped,comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TSource>> GroupBy<TSource, TKey>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityTasked,comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <param name="comparer">The means by which elements are compared</param>
		/// <returns>The set of result</returns>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TSource>> GroupBy<TSource, TKey>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
			,IEqualityComparer<TKey> comparer
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityWrapped,comparer);
		}
		/// <summary>
		/// Form groups of elements using a key selector.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TSource>> GroupBy<TSource, TKey>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, TKey> keySelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			return GroupByInternal(source, QuickFunctions.WrapValueTask(keySelector), QuickFunctions<TSource>.IdentityWrapped,null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TSource>> GroupBy<TSource, TKey>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, Task<TKey>> keySelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityTasked,null);
		}
		/// <summary>
		/// Form groups of elements using a key selector.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The type used as the key for grouping</typeparam>
		/// <param name="source">The sequence of elements</param>
		/// <param name="keySelector">The function to extract keys from the elements</param>
		/// <returns>The set of result</returns>
		/// <remarks>The default equality comparer for <typeparamref name="TKey"/> will be used</remarks>
		public static IAsyncEnumerable<IAsyncGrouping<TKey,TSource>> GroupBy<TSource, TKey>(
			this IAsyncEnumerable<TSource> source,
			Func<TSource, ValueTask<TKey>> keySelector
		)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			return GroupByInternal(source, keySelector, QuickFunctions<TSource>.IdentityWrapped,null);
		}
		#endregion
	}
}

