using Mov.Core.Locations;
using Mov.Core.Models;

namespace Mov.Core.Translators.Services
{
    public class NullTranslatorService : ITranslatorService
    {
        public void Dispose()
        {

        }

        public string Get(Identifier<int> index, Language location)
        {
            return string.Empty;
        }
    }
}
