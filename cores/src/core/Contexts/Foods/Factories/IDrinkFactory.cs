using Mov.Core.Contexts.Foods.ValueObjects;

namespace Mov.Core.Contexts.Foods.Factories
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
