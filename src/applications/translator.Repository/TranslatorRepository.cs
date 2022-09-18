using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Repository
{
    public class TranslatorRepository : FileDomainRepositoryBase
    {
        public TranslatorRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {
            Translates = new DbObjectRepository<Translate, TranslateCollection>(dir, GetRelativePath("translate"), encode);
        }

        public IDbObjectRepository<Translate> Translates { get; }
    }
}
