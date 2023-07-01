using Mov.Core.Models.ValueObjects.Products.Car;

namespace Mov.Core.Models.Entities.Products
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
