using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DamienTheUnbeliever.System.Linq.Tests
{
  
  public class TasksWithDelays<TElement> : IEnumerable<Task<TElement>>
  {
    private readonly List<Task<TElement>> _tasks;

    public TasksWithDelays(params (TElement element, int delay)[] valuesAndDelays)
    {
      _tasks = valuesAndDelays
        .Select(item => Task.Delay(item.delay).ContinueWith(_ => item.element))
        .ToList();
    }

    public IEnumerator<Task<TElement>> GetEnumerator()
    {
      return _tasks.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
