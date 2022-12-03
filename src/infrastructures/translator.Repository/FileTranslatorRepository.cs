using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Repository
{
    public class FileTranslatorRepository : FileDomainRepositoryBase, ITranslatorRepository
    {
        public override string DomainPath => "translator";
        public FileTranslatorRepository(string endpoint, string fileDir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) 
            : base(endpoint, fileDir, extension, encode)
        {
            Translates = new FileDbObjectRepository<Translate, TranslateCollection>(GetPath("translate"), encode);
        }

        public IDbObjectRepository<Translate, TranslateCollection> Translates { get; }
    }
}
