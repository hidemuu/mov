using Mov.Core.Models.Units;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Contexts.Products.Car
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}