using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        protected readonly ISpecification<T>[] Items;

        public CompositeSpecification(params ISpecification<T>[] items)
        {
            Items = items;
        }

        public abstract bool IsSatisfied(T item);

    }
}
