using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Transaction.Implements
{
    public class EntityRepositoryTransactionCommand : ITransactionCommand
    {
        #region プロパティ

        public IConnection Connection { get; }

        public ITransaction Transaction { get; }

        #endregion プロパティ

        #region コンストラクター

        public EntityRepositoryTransactionCommand()
        {

        }

        #endregion コンストラクター

        #region メソッド

        public object Execute(string command)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery(string command)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
