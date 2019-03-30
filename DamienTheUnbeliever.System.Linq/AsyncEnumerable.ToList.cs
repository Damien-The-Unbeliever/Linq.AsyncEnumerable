using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq
{
  public static partial class AsyncEnumerable
  {
    #region API
    /// <summary>
    /// Creates a <see cref="List{T}"/> from an <see cref="IAsyncEnumerable{T}"/>
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the <paramref name="source"/></typeparam>
    /// <param name="source">An <see cref="IAsyncEnumerable{T}"/> to create the <see cref="List{T}"/> from</param>
    /// <returns>A <see cref="List{T}"/> that contains values of type <typeparamref name="TSource"/> selected from the input sequence.</returns>
    public static Task<List<TSource>> ToList<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      if (source == null) throw new ArgumentNullException(nameof(source));
      return ToListInternal(source);
    }

    #endregion
    #region Implementation
    private static async Task<List<TSource>> ToListInternal<TSource>(
      this IAsyncEnumerable<TSource> source)
    {
      var list = new List<TSource>();
      await foreach(var item in source)
      {
        list.Add(item);
      }
      return list;
    }
    #endregion
  }
}
