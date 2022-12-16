using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Transaction
{
    public interface IConnection
    {
        void Open();

        ITransaction BeginTransaction();
    }
}
