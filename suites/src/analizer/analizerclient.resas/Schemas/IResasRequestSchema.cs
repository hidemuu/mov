using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas
{
    public interface IResasRequestSchema
    {
        #region property

        IReadOnlyDictionary<string, string> Parameters { get; }

        #endregion property

    }
}
