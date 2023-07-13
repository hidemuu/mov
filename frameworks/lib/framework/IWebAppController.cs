using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Framework
{
    public interface IWebAppController
    {
        #region property
        IMovRepository Repository { get; }

        #endregion property
    }
}
