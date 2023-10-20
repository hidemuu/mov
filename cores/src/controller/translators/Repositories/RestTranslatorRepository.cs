using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Core.Translators.Models.Schemas;
using System.Collections.Generic;

namespace Mov.Core.Translators.Repositories
{
    public class RestTranslatorRepository : ITranslatorRepository
    {
        #region field

        private readonly string _url;

        #endregion field

        #region property

        public IDbRepository<LocalizeSchema, int> Localizes => new RestDbRepository<LocalizeSchema, int>(_url, EncodingValue.UTF8, new Dictionary<string, string>());

        #endregion property

        #region constructor

        public RestTranslatorRepository(string url)
        {
            _url = url;
        }

        #endregion constructor
    }
}
