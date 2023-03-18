using Mov.Analizer.Models.Apis.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository.Parameters
{
    public class ResasParameter : IResasContext
    {
        #region フィールド

        #endregion フィールド

        #region プロパティ

        public IResasRepository Repository { get; }

        public IResasCommand Command { get; }

        public IResasQuery Query { get; }

        #endregion プロパティ

        #region コンストラクター

        public ResasParameter(IResasRepository repository)
        {
            this.Repository = repository;
        }

        #endregion コンストラクター

    }
}
