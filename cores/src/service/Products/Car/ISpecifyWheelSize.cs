using Mov.Core.Functions.Builders;
using Mov.Core.Models.Physics;

namespace Mov.Core.Models.Products.Car
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthValue size);
    }
}