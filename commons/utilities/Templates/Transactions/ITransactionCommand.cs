using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface ITransactionCommand
    {
        #region プロパティ

        IConnection Connection { get; }

        ITransaction Transaction { get; }

        #endregion プロパティ

        #region メソッド

        void ExecuteNonQuery(string command);

        #endregion メソッド
    }
}
