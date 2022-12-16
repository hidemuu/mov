using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Transaction
{
    /// <summary>トランザクションスコープ</summary>
    public interface ITransaction : IDisposable
    {
        void Begin();

        void Commit();

        void RollBack();
    }
}
