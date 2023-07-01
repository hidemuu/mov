using Mov.Core.Models.Entities.Foods;
using System;

namespace Mov.Core.Templates.Factories.Drinks
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
