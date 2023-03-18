using Mov.Schemas.Elements.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Creators.Factories.Foods.Drinks
{
    public class DrinkMachine
    {

        private List<Tuple<string, IDrinkFactory>> namedFactories =
          new List<Tuple<string, IDrinkFactory>>();

        public DrinkMachine()
        {
            //foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            //{
            //  var factory = (IHotDrinkFactory) Activator.CreateInstance(
            //    Type.GetType("DotNetDesignPatternDemos.Creational.AbstractFactory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
            //  factories.Add(drink, factory);
            //}

            foreach (var t in typeof(DrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    namedFactories.Add(Tuple.Create(
                      t.Name.Replace("Factory", string.Empty), (IDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public Drink MakeDrink()
        {
            Console.WriteLine("Available drinks");
            for (var index = 0; index < namedFactories.Count; index++)
            {
                var tuple = namedFactories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i) // c# 7
                    && i >= 0
                    && i < namedFactories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return namedFactories[i].Item2.Prepare(amount);
                    }
                }
                Console.WriteLine("Incorrect input, try again.");
            }
        }

        //public Drink MakeDrink(AvailableDrink drink, int amount)
        //{
        //  return factories[drink].Prepare(amount);
        //}
    }
}
