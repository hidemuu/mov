using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Composites.Specifications
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
