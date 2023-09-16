using Mov.Core.DesignPatterns.Builders;
using Mov.Core.Maths;

namespace Mov.Core.Products.Car
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthValue size);
    }
}