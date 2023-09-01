namespace Mov.Core.Controllers.Services.Transaction
{
    public interface IConnection
    {
        void Open();

        void Close();

        ITransaction BeginTransaction(int isolationLevel = 0, string name = "");

        ITransactionCommand CreateCommand(ITransaction transaction);

    }
}
