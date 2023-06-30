namespace Mov.Core.Elements.Products.Builders
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
