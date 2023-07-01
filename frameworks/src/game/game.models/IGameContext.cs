namespace Mov.Game.Models
{
    public interface IGameContext
    {
        IGameRepository Repository { get; }

        IGameCommand Command { get; }

        IGameQuery Query { get; }
    }
}