namespace Mov.Core.Templates
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T spec);
    }
}
