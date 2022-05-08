using Mov.Accessors;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Repository
{
    public class TranslatorObjectRepository : FileRepositoryBase<TranslatorObject, TranslatorObjectCollection>
    {
        public TranslatorObjectRepository(string path, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(path, encoding) { }
    }
}
