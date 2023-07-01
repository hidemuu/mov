namespace Mov.Suite.Resas.Models
{
    public interface IResasEngine
    {
        IResasCommand Command { get; }

        IResasQuery Query { get; }
    }
}
