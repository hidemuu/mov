using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Repository
{
    public class FileTranslatorRepository : FileDomainRepositoryBase
    {
        public FileTranslatorRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {
            Translates = new FileDbObjectRepository<Translate, TranslateCollection>(dir, GetRelativePath("translate"), encode);
        }

        public IDbObjectRepository<Translate, TranslateCollection> Translates { get; }
    }
}
