namespace Mov.Core.Authorizers.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public void AddTransactionToAccount(string accountName, decimal transactionAmount)
        {
            var account = repository.GetByName(accountName);
            account.AddTransaction(transactionAmount);
        }

    }
}
