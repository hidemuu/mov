using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Services.Serializer.FIles;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Implements.DbObjects;
using Mov.Core.Repositories.Implements.DbTables;
using Mov.Core.Translators.Repositories.Schemas;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

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
            var serializer = new FileSerializerFactory(new PathValue(Path.Combine(endpoint, FILE_NAME_TRANSLATE)), EncodingValue.UTF8).Create(AccessType.Create(FileType.Json));
            Translates = new FileDbObjectRepository<TranslateSchema, int>(serializer);
        }

        #endregion constructor
    }
}
