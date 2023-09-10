namespace Mov.Core.Functions.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T spec);
    }
}
