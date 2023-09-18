using Mov.Core.Locations.Models;
using Mov.Core.Models;
using Mov.Core.Stores;
using Mov.Core.Translators.Models.Entities;

namespace Mov.Core.Translators.Services
{
    public class NullTranslatorService : ITranslatorService
    {
        public IStoreQuery<LocalizeContent, int> LocalizeContentQuery => throw new System.NotImplementedException();

        public void Dispose()
        {

        }

    }
}
