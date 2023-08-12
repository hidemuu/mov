using Mov.Core.Models.Identifiers;
using Mov.Core.Models.Locations;
using Mov.Core.Templates;
using Mov.Core.Translators.Models;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators.Services
{
    public sealed class TranslatorService : ITranslatorService
    {
        #region field

        private IDatabase<LocalizeContent, IdentifierIndex> database;

        #endregion field

        #region constructor

        public TranslatorService(ITranslatorRepository repository)
        {
            this.database = new TranslatorDatabase(repository);
        }

        #endregion constructor

        #region method

        public string Get(IdentifierIndex index, Language location)
        {
            var content = this.database.Get(index);
            return content.Get(location).Description.Value;
        }

        public void Dispose()
        {
            this.database = null;
        }

        #endregion method
    }
}