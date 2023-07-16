using Mov.Core.Models.Physics;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Contexts.Products.Car
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthValue size);
    }
}