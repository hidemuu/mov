using System;

namespace Mov.Core.Functions
{
    /// <summary>トランザクションスコープ</summary>
    public interface ITransaction : IDisposable
    {
        void Begin();

        void Commit();

        void RollBack();
    }
}
