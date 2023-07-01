using System.Collections.Generic;

namespace Mov.Core.Templates
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }
}
