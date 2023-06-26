using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Transactions
{
    /// <summary>トランザクションスコープ</summary>
    public interface ITransaction : IDisposable
    {
        void Begin();

        void Commit();

        void RollBack();
    }
}
