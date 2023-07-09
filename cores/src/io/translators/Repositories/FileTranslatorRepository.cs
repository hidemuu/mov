using Mov.Core.Repositories.Repositories.DbObjects;
using Mov.Core.Templates.Repositories;
using Mov.Core.Translators.Repositories.Schemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Core.Translators.Repositories
{
    public class FileTranslatorRepository : ITranslatorRepository
    {
        #region constant

        private const string FILE_NAME_TRANSLATE = "translate.json";

        #endregion constant

        #region property

        public IDbObjectRepository<TranslateSchema, TranslateSchemaCollection> Translates { get; }

        #endregion property

        #region constructor

        public FileTranslatorRepository(string endpoint)
        {
            Translates = new FileDbObjectRepository<TranslateSchema, TranslateSchemaCollection>(Path.Combine(endpoint, FILE_NAME_TRANSLATE));
        }

        #endregion constructor
    }
}
