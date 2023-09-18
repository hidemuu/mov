using Mov.Core.DesignPatterns;
using Mov.Core.Locations.Models;
using Mov.Core.Models;
using Mov.Core.Stores;
using Mov.Core.Translators.Models;
using Mov.Core.Translators.Models.Entities;
using Mov.Core.Translators.Stores;
using System;

namespace Mov.Core.Translators.Services
{
    public sealed class TranslatorService : ITranslatorService
    {
        #region field

        private readonly ITranslatorStore _store;

        #endregion field

        #region property

        public IStoreQuery<LocalizeContent, int> LocalizeContentQuery { get; }

        #endregion property

        #region constructor

        public TranslatorService(ITranslatorRepository repository)
        {
            _store = new TranslatorStore(repository);
            LocalizeContentQuery = _store.LocalizeContent.Query;
        }

        #endregion constructor

        #region method

        public void Dispose()
        {
            this._store.LocalizeContent.Command.Dispose();
        }

        #endregion method
    }
}