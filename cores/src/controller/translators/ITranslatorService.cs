using Mov.Core.Locations.Models;
using Mov.Core.Models;
using System;

namespace Mov.Core.Translators
{
    public interface ITranslatorService : IDisposable
    {
        #region method

        string Get(Identifier<int> index, Language location);

        #endregion method
    }
}
