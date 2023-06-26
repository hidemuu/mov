using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }
}
