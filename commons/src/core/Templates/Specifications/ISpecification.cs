namespace Mov.Core.Templates.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }
}
