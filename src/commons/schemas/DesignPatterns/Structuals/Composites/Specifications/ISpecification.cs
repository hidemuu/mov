using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Composites.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }
}
