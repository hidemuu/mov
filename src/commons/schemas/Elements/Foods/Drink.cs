﻿using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Foods
{
    public sealed class Drink : ValueObjectBase<Drink>
    {

        public static Drink Coffee = new Drink("Coffee");

        public static Drink Tea = new Drink("Tea");

        public string Value { get; }

        public Drink(string name)
        {

        }

        protected override bool EqualCore(Drink other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}