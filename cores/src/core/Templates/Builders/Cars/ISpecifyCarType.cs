using Mov.Core.Models.Entities.Products;

namespace Mov.Core.Templates.Builders.Cars
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
