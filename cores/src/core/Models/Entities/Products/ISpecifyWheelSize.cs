using Mov.Core.Models.ValueObjects.Products.Car;
using Mov.Core.Models.ValueObjects.Units;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Models.Entities.Products
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
