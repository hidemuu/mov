﻿using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Products.Cars
{
    public class CarType : ValueObjectBase<CarType>
    {

        public static CarType Sedan = new CarType("Sedan");

        public static CarType Crossover = new CarType("Crossover");


        public string Value { get; }

        public CarType(string carType)
        {
            Value = carType;
        }

        protected override bool EqualCore(CarType other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}