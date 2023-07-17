using Mov.Core.Models.Identifiers;
using Mov.Core.Models.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators
{
    public interface ITranslatorService : IDisposable
    {
        #region method

        string Get(IdentifierCode code, Language location);

        #endregion method
    }
}
