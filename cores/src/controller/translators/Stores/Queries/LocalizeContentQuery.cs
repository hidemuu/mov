using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators.Stores.Queries
{
    internal class LocalizeContentQuery : IStoreQuery<LocalizeContent, int>
    {
        #region property

        public IRead<LocalizeContent, int> Reader { get; }

        #endregion property

        #region constructor

        public LocalizeContentQuery(ITranslatorRepository repository)
        {

        }

        #endregion constructor
    }
}
