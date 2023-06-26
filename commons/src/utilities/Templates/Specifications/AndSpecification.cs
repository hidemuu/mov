using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mov.Utilities.Helpers;

namespace Mov.Utilities.Templates.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(params ISpecification<T>[] items) : base(items)
        {
        }

        public override bool IsSatisfied(T item)
        {
            return Items.All(i => i.IsSatisfied(item));
        }
    }
}
