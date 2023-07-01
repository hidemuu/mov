using Mov.Core.Models.ValueObjects.Manufactures.Products;

namespace Mov.Core.Models.Entities.Manucactures.Products
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
