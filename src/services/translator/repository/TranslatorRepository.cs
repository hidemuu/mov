using Accessors;
using Translator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Translator.Repository
{
    public class TranslatorRepository : ITranslatorRepository
    {
        public TranslatorRepository(string path, FileType fileType, string encoding = "utf-8")
        {
            switch (fileType)
            {
                case FileType.Json:
                    Comments = new CommentRepository(new JsonFileHelper(Path.Combine(path, CommentRepository.FILE_NAME), encoding));
                    break;
                default:
                    Comments = new CommentRepository(new XmlFileHelper(Path.Combine(path, CommentRepository.FILE_NAME), encoding));
                    break;
            }
        }

        public ICommentRepository Comments { get; }

    }
}
