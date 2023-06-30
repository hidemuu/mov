using System;

namespace Mov.Core.Templates.Transactions
{
    /// <summary>トランザクションスコープ</summary>
    public interface ITransaction : IDisposable
    {
        void Begin();

        void Commit();

        void RollBack();
    }
}
