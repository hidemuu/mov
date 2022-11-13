using Mov.Analizer.Models.Persistences;
using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Parameters
{
    public interface IResasParameter
    {
        #region プロパティ

        IResasRepository Repository { get; }

        IResasCommand Command { get; }

        IResasQuery Query { get; }

        #endregion プロパティ
    }
}
