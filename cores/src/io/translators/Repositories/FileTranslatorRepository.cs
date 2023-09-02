using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Services.DbObjects;
using Mov.Core.Repositories.Services.DbObjects.Implements;
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