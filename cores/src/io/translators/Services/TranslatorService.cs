using Mov.Core.Models.Keys;
using Mov.Core.Models.Units;
using Mov.Core.Templates;
using Mov.Core.Translators.Models.Entities;
using Mov.Core.Translators.Repositories;

namespace Mov.Core.Translators.Services
{
    public class TranslatorService
    {
        #region field

        private readonly IDatabase<LocalizeContent, IdentifierCode> database;

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

        #endregion method
    }
}