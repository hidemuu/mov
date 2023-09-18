using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Translators.Stores.Queries
{
    internal class LocalizeContentReader : IRead<LocalizeContent, int>
    {
        #region field

        private readonly ITranslatorRepository _repository;

        #endregion field

        #region constructor

        public LocalizeContentReader(ITranslatorRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public LocalizeContent Read(int id)
        {
            var result = Task.WhenAll(_repository.Translates.GetAsync(id)).Result[0];
            return new LocalizeContent(result);
        }

        public IEnumerable<LocalizeContent> ReadAll()
        {
            var result = Task.WhenAll(_repository.Translates.GetAsync()).Result[0];
            foreach (var item in result)
            {
                yield return new LocalizeContent(item);
            }
        }

        #endregion method
    }
}
