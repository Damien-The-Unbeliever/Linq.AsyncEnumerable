using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  namespace Transform
  {
    public class Aggregate
    {
      [Fact]
      public void Eagerly_Validates_Source_Plain_Seed_Plain_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(null, 0, (a, b) => a + b, a => a);
        });
      }

      [Fact]
      public void Eagerly_Validates_Source_Value_Seed_Plain_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(null, new ValueTask<int>(0), (a, b) => a + b, a => a);
        });
      }

      [Fact]
      public void Eagerly_Validates_Source_Plain_Seed_Value_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(null, 0, (a, b) => new ValueTask<int>(a + b), a => a);
        });
      }

      [Fact]
      public void Eagerly_Validates_Source_Value_Seed_Value_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(null, new ValueTask<int>(0), (a, b) => new ValueTask<int>(a + b), a => a);
        });
      }


      [Fact]
      public void Eagerly_Validates_Source_Plain_Seed_Task_Func_Task_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(null, 0, (a, b) => Task.FromResult(a + b), a => Task.FromResult(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Source_Task_Seed_Task_Func_Task_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(null, Task.FromResult(0), (a, b) => Task.FromResult(a + b), a => Task.FromResult(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Plain_Seed_Plain_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), 0, (Func<int, int, int>)null, a => a);
        });
      }


      [Fact]
      public void Eagerly_Validates_Transform_Plain_Seed_Plain_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), 0, (a, b) => a + b, (Func<int, int>)null);
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Value_Seed_Plain_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), new ValueTask<int>(0), (Func<int, int, int>)null, a => a);
        });
      }

      [Fact]
      public void Eagerly_Validates_Transform_Value_Seed_Plain_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), new ValueTask<int>(0), (a, b) => a + b, (Func<int, int>)null);
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Plain_Seed_Value_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), 0, (Func<int, int, ValueTask<int>>)null, a => a);
        });
      }


      [Fact]
      public void Eagerly_Validates_Trasnform_Plain_Seed_Value_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), 0, (a,b)=>new ValueTask<int>(a+b),(Func<int,int>)null);
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Value_Seed_Value_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), new ValueTask<int>(0), (Func<int, int, ValueTask<int>>)null, a => a);
        });
      }

      [Fact]
      public void Eagerly_Validates_Transform_Value_Seed_Value_Func_Plain_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), new ValueTask<int>(0), (a,b)=>new ValueTask<int>(a+b), (Func<int,int>)null);
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Plain_Seed_Task_Func_Task_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), 0, (Func<int, int, Task<int>>)null, a => Task.FromResult(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Transform_Plain_Seed_Task_Func_Task_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), 0, (a, b) => Task.FromResult(a + b), (Func<int,Task<int>>)null);
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Task_Seed_Task_Func_Task_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), Task.FromResult(0), (Func<int, int, Task<int>>)null, a => Task.FromResult(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Transform_Task_Seed_Task_Func_Task_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), Task.FromResult(0), (a,b)=>Task.FromResult(a+b), (Func<int,Task<int>>)null);
        });
      }


      [Fact]
      public void Eagerly_Validates_Seed_Task_Seed_Task_Func_Task_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate<int, int, int>(AsyncEnumerable.Empty<int>(), null, (Func<int, int, Task<int>>)null, a => Task.FromResult(a));
        });
      }

      [Fact]
      public async Task Empty_Sequence_Yields_Seed_Plain_Seed_Plain_Func_Plain_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(19, (a, b) => a + b, a => a);

        Assert.Equal(19, actual);
      }
      [Fact]
      public async Task Empty_Sequence_Yields_Seed_Value_Seed_Plain_Func_Plain_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(new ValueTask<int>(19), (a, b) => a + b, a => a);

        Assert.Equal(19, actual);
      }
      [Fact]
      public async Task Empty_Sequence_Yields_Seed_Plain_Seed_Value_Func_Plain_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(19, (a, b) => new ValueTask<int>(a + b), a => a);

        Assert.Equal(19, actual);
      }
      [Fact]
      public async Task Empty_Sequence_Yields_Seed_Value_Seed_Value_Func_Plain_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(new ValueTask<int>(19), (a, b) => new ValueTask<int>(a + b), a => a);

        Assert.Equal(19, actual);
      }

      [Fact]
      public async Task Empty_Sequence_Yields_Seed_Plain_Seed_Task_Func_Task_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(19, (a, b) => Task.FromResult(a + b), a => Task.FromResult(a));

        Assert.Equal(19, actual);
      }

      [Fact]
      public async Task Empty_Sequence_Yields_Seed_Task_Seed_Task_Func_Task_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(Task.FromResult(19), (a, b) => Task.FromResult(a + b), a => Task.FromResult(a));

        Assert.Equal(19, actual);
      }


      [Fact]
      public void Eagerly_Validates_Source_Plain_Seed_Value_Func_Value_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate((IAsyncEnumerable<int>)null, 0, (a, b) => new ValueTask<int>(a+b), a => new ValueTask<int>(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Plain_Seed_Value_Func_Value_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate(AsyncEnumerable.Empty<int>(), 0, (Func<int,int,ValueTask<int>>)null, a => new ValueTask<int>(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Transform_Plain_Seed_Value_Func_Value_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate(AsyncEnumerable.Empty<int>(), 0, (a, b) => new ValueTask<int>(a + b), (Func<int,ValueTask<int>>)null);
        });
      }

      [Fact]
      public async Task Empty_Sequence_Yieldsw_Seed_Plain_Seed_Value_Func_Value_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(7, (a, b) => new ValueTask<int>(a + b), a => new ValueTask<int>(a));

        Assert.Equal(7, actual);
      }


      [Fact]
      public void Eagerly_Validates_Source_Plain_Seed_Plain_Func_Value_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate((IAsyncEnumerable<int>)null, 0, (a, b) => a + b, a => new ValueTask<int>(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Func_Plain_Seed_Plain_Func_Value_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate(AsyncEnumerable.Empty<int>(), 0, (Func<int, int, int>)null, a => new ValueTask<int>(a));
        });
      }

      [Fact]
      public void Eagerly_Validates_Transform_Plain_Seed_Plain_Func_Value_Transform()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          var iter = AsyncEnumerable.Aggregate(AsyncEnumerable.Empty<int>(), 0, (a, b) => a + b, (Func<int, ValueTask<int>>)null);
        });
      }

      [Fact]
      public async Task Empty_Sequence_Yieldsw_Seed_Plain_Seed_Plain_Func_Value_Transform()
      {
        var source = AsyncEnumerable.Empty<int>();

        var actual = await source.Aggregate(7, (a, b) => a + b, a => new ValueTask<int>(a));

        Assert.Equal(7, actual);
      }
    }
  }
}
