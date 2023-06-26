using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizers
{
    public interface IAccountService
    {
        void AddTransactionToAccount(string accountName, decimal transactionAmount);
    }
}
