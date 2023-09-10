using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.DbObjects;
using Mov.Core.Translators.Models.Schemas;
using System.IO;

namespace Mov.Core.Translators.Repositories
{
    public class FileTranslatorRepository : ITranslatorRepository
    {
        #region constant

        private const string FILE_NAME_TRANSLATE = "translate.json";

        #endregion constant

        #region property

        public IDbObjectRepository<TranslateSchema, int> Translates { get; }

        #endregion property

        #region constructor

        public FileTranslatorRepository(string endpoint)
        {
            var client = new FileClient(new PathValue(Path.Combine(endpoint, FILE_NAME_TRANSLATE)), AccessType.Create(FileType.Json));
            Translates = new FileDbObjectRepository<TranslateSchema, int>(client);
        }

        #endregion constructor
    }
}