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
        private readonly string _key;

        #endregion field

        #region property

        public IDbRepository<LocalizeSchema, int> Localizes => new RestDbRepository<LocalizeSchema, int>(_url, _key, EncodingValue.UTF8, new Dictionary<string, string>());

        #endregion property

        #region constructor

        public RestTranslatorRepository(string url, string auth)
        {
            _url = url;
            _key = auth;
        }

        #endregion constructor
    }
}
