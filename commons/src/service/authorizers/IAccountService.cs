namespace Mov.Core.Authorizers
{
    public interface IAccountService
    {
        void AddTransactionToAccount(string accountName, decimal transactionAmount);
    }
}
