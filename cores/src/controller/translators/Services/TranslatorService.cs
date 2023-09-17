using Mov.Core.DesignPatterns;
using Mov.Core.Locations.Models;
using Mov.Core.Models;
using Mov.Core.Translators.Models;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators.Services
{
    public sealed class TranslatorService : ITranslatorService
    {
        #region field

        private IDatabase<LocalizeContent, Identifier<int>> database;

        #endregion field

        #region constructor

        public TranslatorService(ITranslatorRepository repository)
        {
            this.database = new TranslatorDatabase(repository);
        }

        #endregion constructor

        #region method

        public string Get(Identifier<int> index, Language location)
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