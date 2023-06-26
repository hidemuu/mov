using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Clients.Resas
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
