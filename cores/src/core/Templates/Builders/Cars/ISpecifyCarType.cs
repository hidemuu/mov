using Mov.Core.Models.ValueObjects.Manufactures.Products;

namespace Mov.Core.Templates.Builders.Cars
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
