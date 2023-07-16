using Mov.Core.Models.Units;
using Mov.Core.Templates.Builders;
using System;

namespace Mov.Core.Contexts.Products.Car.Builders
{
    public class CarBuilder
    {
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }

        private class Impl :
        ISpecifyCarType,
        ISpecifyWheelSize,
        IBuilder<Car>
        {
            private CarType carType = CarType.Sedan;
            private LengthValue wheelSize = LengthValue.Default;

            public ISpecifyWheelSize OfType(CarType type)
            {
                carType = type;
                return this;
            }

            public IBuilder<Car> WithWheels(LengthValue size)
            {
                if (carType.Equals(CarType.Sedan))
                {
                    if (size.Value < 17 || size.Value > 20)
                    {
                        throw new ArgumentException($"Wrong size of wheel for {carType}.");
                    }
                }
                if (carType.Equals(CarType.Crossover))
                {
                    if (size.Value < 15 || size.Value > 17)
                    {
                        throw new ArgumentException($"Wrong size of wheel for {carType}.");
                    }
                }
                wheelSize = size;
                return this;
            }

            public Car Build()
            {
                return new Car(carType, wheelSize);
            }
        }
    }
}