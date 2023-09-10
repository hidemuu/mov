using Mov.Core.Locations;
using Mov.Core.Models.Identifiers;

namespace Mov.Core.Translators.Services
{
    public class NullTranslatorService : ITranslatorService
    {
        public void Dispose()
        {

        }

        public string Get(IdentifierIndex index, Language location)
        {
            return string.Empty;
        }
    }
}
