﻿using Mov.Core.Models;
using Mov.Core.Models.Physics;
using System;

namespace Mov.Core.Models.Products.Car
{
    public class Car : ValueObjectBase<Car>
    {

        public CarType CarType { get; }

        public LengthValue WheelSize { get; }

        public Car(CarType carType, LengthValue wheelSize)
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