using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Composites.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        protected readonly ISpecification<T>[] Items;

        public CompositeSpecification(params ISpecification<T>[] items)
        {
            this.Items = items;
        }

        public abstract bool IsSatisfied(T item);

    }
}
