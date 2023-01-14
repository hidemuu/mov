using Mov.Schemas.Elements.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Factories.Foods.Drinks
{
    internal class CoffeeFactory : IDrinkFactory
    {
        public Drink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return Drink.Coffee;
        }
    }
}
