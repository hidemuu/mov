using Mov.Schemas.Elements.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Factories.Foods.Drinks
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
