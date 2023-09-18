using Mov.Core.Locations.Models;
using Mov.Core.Models;
using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;
using System;

namespace Mov.Core.Translators
{
    public interface ITranslatorService : IDisposable
    {
        #region property

        IStoreQuery<LocalizeContent, int> LocalizeContentQuery { get; }

        #endregion property

        #region method



        #endregion method
    }
}
