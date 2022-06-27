using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Models
{
    public interface ITranslatorRepositoryCollection
    {
        DbObjectRepositoryBase<TranslatorObject, TranslatorObjectCollection> Comments { get; }
    }
}
