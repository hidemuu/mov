using Mov.Core.Models.Entities.Products;

namespace Mov.Core.Models.Builders
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
