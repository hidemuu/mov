using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
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

        public IDbRepository<LocalizeSchema, int, DbRequestSchemaString> Localizes { get; }

        #endregion property

        #region constructor

        public FileTranslatorRepository(string endpoint)
        {
            var client = new FileClient(new PathValue(Path.Combine(endpoint, FILE_NAME_TRANSLATE)), AccessType.Create(FileType.Json));
            Localizes = FileDbRepository<LocalizeSchema, int>.Factory.Create(client);
        }

        #endregion constructor
    }
}