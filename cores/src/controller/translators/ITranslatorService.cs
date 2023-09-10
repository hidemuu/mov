using Mov.Core.Locations;
using Mov.Core.Models.Identifiers;
using System;

namespace Mov.Core.Translators
{
    public interface ITranslatorService : IDisposable
    {
        #region method

        string Get(IdentifierIndex index, Language location);

        #endregion method
    }
}
