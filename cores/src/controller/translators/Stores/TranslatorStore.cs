using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators.Stores
{
    internal class TranslatorStore : ITranslatorStore
    {
        #region field

        private readonly ITranslatorRepository _repository;

        #endregion field

        #region property

        public IStore<LocalizeContent, int> LocalizeContent { get; }

        #endregion property

        #region constructor

        public TranslatorStore(ITranslatorRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor
    }
}
