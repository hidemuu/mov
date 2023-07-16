using Mov.Core.Models.Physics;
using Mov.Core.Templates.Builders;

namespace Mov.Core.Models.Products.Car
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthValue size);
    }
}