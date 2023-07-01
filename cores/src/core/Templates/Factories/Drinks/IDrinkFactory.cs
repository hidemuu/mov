using Mov.Core.Models.ValueObjects.Foods;

namespace Mov.Core.Templates.Factories.Drinks
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
