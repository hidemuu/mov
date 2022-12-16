using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Transaction.Implements
{
    public class EntityRepositoryTransactionCommand : ITransactionCommand
    {
        public IConnection Connection => throw new NotImplementedException();

        public ITransaction Transaction => throw new NotImplementedException();

        public object Execute(string command)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery(string command)
        {
            throw new NotImplementedException();
        }
    }
}
