using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators.Stores
{
    internal class LocalizeContentStore : IStore<LocalizeContent, int>
    {
        #region property

        public IStoreQuery<LocalizeContent, int> Query { get; }

        public IStoreCommand<LocalizeContent, int> Command { get; }

        #endregion property

        #region constructor

        public LocalizeContentStore(ITranslatorRepository repository)
        {
        }

        #endregion constructor
    }
}
