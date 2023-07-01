namespace Mov.Core.Models.Entities.Foods
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
