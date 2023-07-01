namespace Mov.Suite.Resas.Models
{
    public interface IResasContext
    {
        #region プロパティ

        IResasRepository Repository { get; }

        IResasCommand Command { get; }

        IResasQuery Query { get; }

        #endregion プロパティ
    }
}
