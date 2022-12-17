using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Parameters
{
    public interface IDesignerContext : IDisposable
    {
        #region プロパティ

        string EndPoint { get; }

        IDesignerRepository Repository { get; }
        
        IDesignerCommand Command { get; }

        IDesignerQuery Query { get; }

        #endregion プロパティ

    }
}
