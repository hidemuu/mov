using Mov.Schemas.Elements.Products;
using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Products.Cars.Builders
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
            CarType carType = CarType.Sedan;
            LengthUnit wheelSize = LengthUnit.Default;


            public ISpecifyWheelSize OfType(CarType type)
            {
                carType = type;
                return this;
            }

            public IBuilder<Car> WithWheels(LengthUnit size)
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
