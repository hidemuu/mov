using Mov.Core.DesignPatterns.Builders;
using Mov.Core.Valuables;

namespace Mov.Core.Products.Car
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthValue size);
    }
}