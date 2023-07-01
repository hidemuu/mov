using Mov.Core.Models.Entities.Products;
using Mov.Core.Models.ValueObjects.Units;

namespace Mov.Core.Templates.Builders.Cars
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
