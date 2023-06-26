using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T spec);
    }
}
