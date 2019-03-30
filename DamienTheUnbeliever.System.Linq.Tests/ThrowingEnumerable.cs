using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class ThrowingEnumerable<TSource> : IEnumerable<TSource>
  {
    public IEnumerator<TSource> GetEnumerator()
    {
      throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }
  }
}
