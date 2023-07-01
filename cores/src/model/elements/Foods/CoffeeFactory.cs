using System;

namespace Mov.Core.Elements.Foods
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
