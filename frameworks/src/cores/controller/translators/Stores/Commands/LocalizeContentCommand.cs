using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;
using System;

namespace Mov.Core.Translators.Stores.Commands
{
    internal class LocalizeContentCommand : IStoreCommand<LocalizeContent>
    {
        #region property

        public ISave<LocalizeContent> Saver { get; }

        public IDelete<LocalizeContent> Deleter { get; }

        #endregion property

        #region constructor

        public LocalizeContentCommand(ITranslatorRepository repository)
        {
            Saver = new LocalizeContentSaver(repository);
            Deleter = new LocalizeContentDeleter(repository);
        }

        #endregion constructor

        #region method

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
