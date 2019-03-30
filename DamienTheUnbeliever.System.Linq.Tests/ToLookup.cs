using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  public class ToLookup
  {
    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_No_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k);
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_No_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_No_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => k);

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Value_Key_No_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => new ValueTask<int>(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Value_Key_No_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<int>>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Value_Key_No_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => new ValueTask<int>(k));

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Key_No_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => Task.FromResult(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Task_Key_No_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, Task<int>>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Task_Key_No_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => Task.FromResult(k));

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_No_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k, new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_No_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_No_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => k, new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Value_Key_No_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => new ValueTask<int>(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Value_Key_No_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<int>>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Value_Key_No_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => new ValueTask<int>(k), new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Key_No_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => Task.FromResult(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Task_Key_No_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, Task<int>>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Task_Key_No_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => Task.FromResult(k), new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }


    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k, k => k);
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, k => k);
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Plain_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => k, (Func<int, int>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_Plain_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => k, k => k);

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Value_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => new ValueTask<int>(k), k => k);
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Value_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<int>>)null, k => k);
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Value_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => new ValueTask<int>(k), (Func<int, int>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Value_Key_Plain_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => new ValueTask<int>(k), k => k);

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => Task.FromResult(k), k => k);
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Task_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, Task<int>>)null, k => k);
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Task_Key_Plain_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => Task.FromResult(k), (Func<int, int>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Task_Key_Plain_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => Task.FromResult(k), k => k);

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k, k => k, new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, k => k, new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Plain_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => k, (Func<int, int>)null,new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_Plain_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => k, k => k, new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Value_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => new ValueTask<int>(k), k => k, new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Value_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<int>>)null, k => k, new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Value_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => new ValueTask<int>(k), (Func<int, int>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Value_Key_Plain_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => new ValueTask<int>(k), k => k, new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_Value_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k, k => new ValueTask<int>(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_Value_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, k => new ValueTask<int>(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Plain_Key_Value_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => k, (Func<int, ValueTask<int>>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_Value_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => k, k => new ValueTask<int>(k));

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Value_Key_Value_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => new ValueTask<int>(k), k => new ValueTask<int>(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Value_Key_Value_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<int>>)null, k => new ValueTask<int>(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Value_Key_Value_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => new ValueTask<int>(k), (Func<int, ValueTask<int>>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Value_Key_Value_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int,int> target = source.ToLookup(k => new ValueTask<int>(k), k => new ValueTask<int>(k));

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_Value_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k, k => new ValueTask<int>(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_Value_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, k => new ValueTask<int>(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Plain_Key_Value_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => k, (Func<int, ValueTask<int>>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_Value_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int, int> target = source.ToLookup(k => k, k => new ValueTask<int>(k), new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Value_Key_Value_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => new ValueTask<int>(k), k => new ValueTask<int>(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Value_Key_Value_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, ValueTask<int>>)null, k => new ValueTask<int>(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Value_Key_Value_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => new ValueTask<int>(k), (Func<int, ValueTask<int>>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Value_Key_Value_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int, int> target = source.ToLookup(k => new ValueTask<int>(k), k => new ValueTask<int>(k), new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Key_Task_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => Task.FromResult(k), k => Task.FromResult(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Task_Key_Task_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, Task<int>>)null, k => Task.FromResult(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Task_Key_Task_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => Task.FromResult(k), (Func<int, Task<int>>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Task_Key_Task_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int, int> target = source.ToLookup(k => Task.FromResult(k), k => Task.FromResult(k));

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Key_Task_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => Task.FromResult(k), k => Task.FromResult(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Task_Key_Task_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int,int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, Task<int>>)null, k => Task.FromResult(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Task_Key_Task_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => Task.FromResult(k), (Func<int, Task<int>>)null,new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Task_Key_Task_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int, int> target = source.ToLookup(k => Task.FromResult(k), k => Task.FromResult(k),new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }


    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_Task_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k, k => Task.FromResult(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_Task_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, k => Task.FromResult(k));
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Plain_Key_Task_Element_No_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => k, (Func<int, Task<int>>)null);
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_Task_Element_No_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int, int> target = source.ToLookup(k => k, k => Task.FromResult(k));

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Plain_Key_Task_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => k, k => Task.FromResult(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Plain_Key_Task_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, int>)null, k => Task.FromResult(k), new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Plain_Key_Task_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => k, (Func<int, Task<int>>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Plain_Key_Task_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int, int> target = source.ToLookup(k => k, k => Task.FromResult(k), new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public void Eagerly_Validates_Source_Task_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup((IAsyncEnumerable<int>)null, k => Task.FromResult(k), k => k, new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Key_Task_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), (Func<int, Task<int>>)null, k => k, new IntComparer());
      });
    }

    [Fact]
    public void Eagerly_Validates_Element_Task_Key_Plain_Element_Comparer()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        IAsyncLookup<int, int> iter = AsyncEnumerable.ToLookup(AsyncEnumerable.Empty<int>(), k => Task.FromResult(k), (Func<int, int>)null, new IntComparer());
      });
    }

    [Fact]
    public async Task Empty_Sequence_Produces_Empty_Lookup_Task_Key_Plain_Element_Comparer()
    {
      var source = AsyncEnumerable.Empty<int>();

      IAsyncLookup<int, int> target = source.ToLookup(k => Task.FromResult(k), k => k, new IntComparer());

      Assert.Equal(0, await target.GetCount());
    }

    [Fact]
    public async Task Multi_Sequence_Basic()
    {
      var source = Enumerable.Range(0, 20).AsAsyncEnumerable();

      IAsyncLookup<int, int> target = source.ToLookup(k => k % 8);

      Assert.Equal(8, await target.GetCount());
    }

    [Fact]
    public async Task Multi_Sequence_With_Comparer()
    {
      var source = Enumerable.Range(0, 3).AsAsyncEnumerable();

      IAsyncLookup<int, int> target = source.ToLookup(k => k % 8, new ModComparer());

      Assert.True(await target.ContainsKey(2));
      Assert.False(await target.ContainsKey(3));

    }
  }
}
