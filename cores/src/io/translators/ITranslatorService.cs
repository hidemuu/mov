using Mov.Core.Models.Keys;
using Mov.Core.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators
{
    public interface ITranslatorService : IDisposable
    {
        #region method

        string Get(IdentifierCode code, Location location);

        #endregion method
    }
}
