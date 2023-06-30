using System.Linq;

namespace Mov.Core.Templates.Specifications
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
