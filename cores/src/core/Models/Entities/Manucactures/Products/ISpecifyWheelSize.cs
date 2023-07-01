using Mov.Core.Models.ValueObjects.Manufactures.Products;
using Mov.Core.Models.ValueObjects.Units;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Models.Entities.Manucactures.Products
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
