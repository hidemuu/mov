using Mov.Accessors;
using Mov.Framework;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Repository
{
    public class TranslatorRepository : DomainRepositoryBase
    {
        public TranslatorRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            Translates = new DbObjectRepository<Translate, TranslateCollection>(dir, GetRelativePath("translate"), encode);
        }

        public IDbObjectRepository<Translate> Translates { get; }
    }
}
