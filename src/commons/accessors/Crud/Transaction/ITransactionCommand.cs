using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Transaction
{
    public interface ITransactionCommand
    {
        #region プロパティ

        ITransaction Transaction { get; }

        string CommandText { get; }

        #endregion プロパティ

        #region メソッド

        void ExecuteNonQuery();

        object Execute();

        #endregion メソッド
    }
}
