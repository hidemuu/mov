using Mov.Core.Functions.Builders;
using Mov.Core.Maths;

namespace Mov.Core.Products.Car
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthValue size);
    }
}