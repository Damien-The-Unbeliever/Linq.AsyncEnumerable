using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DamienTheUnbeliever.System.Linq.Tests")]

namespace DamienTheUnbeliever.System.Linq
{
  /// <summary>
  /// Provides a set of static (Shared in Visual Basic) methods for querying objects that implement <see cref="IAsyncEnumerable{T}"/>.
  /// </summary>
  public static partial class AsyncEnumerable
  {
    private const string NoElement = "Sequence contained no matching element";
    private const string MultipleElements = "Multiple elements found";

    internal class QuickFunctions<TSource>
    {
      public static Func<TSource, TSource> Identity = x => x;
      public static Func<TSource, ValueTask<bool>> True = x => new ValueTask<bool>(true);
      public static Func<TSource, ValueTask<bool>> False = x => new ValueTask<bool>(false);
      public static Func<TSource, ValueTask<TSource>> IdentityWrapped = x => new ValueTask<TSource>(x);
      public static Func<TSource, Task<TSource>> IdentityTasked = x => Task.FromResult(x);
    }
    internal class QuickFunctions
    {
      public static Func<TFirst, Task<TResult>> WrapTask<TFirst, TResult>(Func<TFirst, TResult> original)
        => first => Task.FromResult(original(first));
      public static Func<TFirst, ValueTask<TResult>> WrapValueTask<TFirst, TResult>(Func<TFirst, TResult> original)
        => first => new ValueTask<TResult>(original(first));
      public static Func<TFirst, TSecond, Task<TResult>> WrapTask<TFirst, TSecond, TResult>(Func<TFirst, TSecond, TResult> original)
        => (first, second) => Task.FromResult(original(first, second));
      public static Func<TFirst, TSecond, ValueTask<TResult>> WrapValueTask<TFirst, TSecond, TResult>(Func<TFirst, TSecond, TResult> original)
        => (first, second) => new ValueTask<TResult>(original(first, second));
    }
  }
}
