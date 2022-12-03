using Mov.Analizer.Models.Parameters;
using Mov.Analizer.Models.Persistences;
using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository.Parameters
{
    public class ResasParameter : IResasParameter
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
