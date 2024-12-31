namespace Mov.Core.DesignPatterns.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T spec);
    }
}
