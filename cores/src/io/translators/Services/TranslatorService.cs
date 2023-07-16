using Mov.Core.Models.Keys;
using Mov.Core.Models.Worlds;
using Mov.Core.Templates;
using Mov.Core.Translators.Models;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators.Services
{
    public sealed class TranslatorService : ITranslatorService
    {
        #region field

        private IDatabase<LocalizeContent, IdentifierCode> database;

        #endregion field

        #region constructor

        public TranslatorService(ITranslatorRepository repository)
        {
            this.database = new TranslatorDatabase(repository);
        }

        #endregion constructor

        #region method

        public string Get(IdentifierCode code, Location location)
        {
            var content = this.database.Get(code);
            return content.Get(location).Description.Value;
        }

        public void Dispose()
        {
            this.database = null;
        }

        #endregion method
    }
}