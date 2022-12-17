using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IConnection
    {
        void Open();

        void Close();

        ITransaction BeginTransaction(int isolationLevel = 0, string name = "");

        ITransactionCommand CreateCommand(ITransaction transaction);

    }
}
