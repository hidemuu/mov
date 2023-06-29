using Mov.Core.Models.ValueObjects.Units;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Elements.Products.Builders
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
