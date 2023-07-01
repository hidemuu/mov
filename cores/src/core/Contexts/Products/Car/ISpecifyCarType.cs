namespace Mov.Core.Contexts.Products.Car
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}