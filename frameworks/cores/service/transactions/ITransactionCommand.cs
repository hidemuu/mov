namespace Mov.Core.Transactions
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
