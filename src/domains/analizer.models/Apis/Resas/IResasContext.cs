using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Apis.Resas
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
