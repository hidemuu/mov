using Mov.Schemas.Units;
using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Products.Cars
{
    public class Car : ValueObjectBase<Car>
    {

        public CarType CarType { get; }

        public LengthUnit WheelSize { get; }

        public Car(CarType carType, LengthUnit wheelSize)
        {
            CarType = carType;
            WheelSize = wheelSize;
        }

        protected override bool EqualCore(Car other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
