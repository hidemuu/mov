using Mov.Core.Models;
using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;
using System.Threading;

namespace Mov.Core.Translators.Stores
{
    internal class TranslatorStore : ITranslatorStore
    {
        #region property

        public Identifier<int> Id { get; }

        public IStore<LocalizeContent, int> LocalizeContent { get; }

        #endregion property

        #region constructor

        public TranslatorStore(ITranslatorRepository repository)
        {
            Id = new Identifier<int>(Thread.CurrentThread.ManagedThreadId);
            LocalizeContent = new LocalizeContentStore(repository);
        }

        #endregion constructor
    }
}
