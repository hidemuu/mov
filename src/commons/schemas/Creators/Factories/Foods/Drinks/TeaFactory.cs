using Mov.Schemas.Elements.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Creators.Factories.Foods.Drinks
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
