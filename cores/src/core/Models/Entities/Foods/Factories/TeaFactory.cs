﻿using Mov.Core.Models.ValueObjects.Foods;
using System;

namespace Mov.Core.Models.Entities.Foods.Factories
{
    internal class TeaFactory : IDrinkFactory
    {
        public Drink Prepare(int amount)
        {
            Console.WriteLine($"Put in tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return Drink.Tea;
        }
    }
}