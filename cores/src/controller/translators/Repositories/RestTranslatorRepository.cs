using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Translators.Repositories
{
    public class RestTranslatorRepository : ITranslatorRepository
    {
        #region field

        private readonly string _url;
        private readonly string _key;

        #endregion field

        #region property

        public IDbRepository<TranslateSchema, int> Translates => new RestDbRepository<TranslateSchema, int>(_url, _key, EncodingValue.UTF8);

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
