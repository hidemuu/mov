using Mov.Driver.Clients.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.Driver.Engine.Resas
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
