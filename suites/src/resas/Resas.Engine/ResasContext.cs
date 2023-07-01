using Mov.Suite.Resas.Models;

namespace Mov.Suite.Resas.Engine
{
    public class ResasContext : IResasContext
    {
        #region フィールド

        #endregion フィールド

        #region プロパティ

        public IResasRepository Repository { get; }

        public IResasCommand Command { get; }

        public IResasQuery Query { get; }

        #endregion プロパティ

        #region コンストラクター

        public ResasContext(IResasRepository repository)
        {
            Repository = repository;
        }

        #endregion コンストラクター

    }
}
