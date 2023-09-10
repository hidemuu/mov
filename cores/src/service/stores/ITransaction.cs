using System;

namespace Mov.Core.Stores
{
    /// <summary>トランザクションスコープ</summary>
    public interface ITransaction : IDisposable
    {
        void Begin();

        void Commit();

        void RollBack();
    }
}
