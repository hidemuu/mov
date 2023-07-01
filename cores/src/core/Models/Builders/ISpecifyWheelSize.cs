using Mov.Core.Models.Entities.Products;
using Mov.Core.Models.ValueObjects.Units;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Models.Builders
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
