using Mov.Core.Models.Identifiers;
using Mov.Core.Models.Locations;
using System;
using System.Collections.Generic;
using System.Text;

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
