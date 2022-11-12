using Mov.Analizer.Models.Parameters;
using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository.Parameters
{
    public class ResasParameter : IResasParameter
    {
        #region フィールド

        private readonly IResasRepository repository;

        #endregion フィールド

        #region プロパティ

        #endregion プロパティ

        #region コンストラクター

        public ResasParameter(IResasRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

    }
}
