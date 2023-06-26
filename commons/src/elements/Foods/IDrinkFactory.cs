using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Elements.Foods
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
