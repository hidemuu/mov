using Mov.Core.Models.ValueObjects.Manufactures.Products;
using Mov.Core.Models.ValueObjects.Units;

namespace Mov.Core.Templates.Builders.Cars
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
