using Mov.Core.Models.Keys;
using Mov.Core.Models.Worlds;
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

        public string Get(IdentifierCode code, Location location)
        {
            return string.Empty;
        }
    }
}
