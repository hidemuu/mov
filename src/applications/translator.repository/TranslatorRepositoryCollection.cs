using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Translator.Repository
{
    public class TranslatorRepositoryCollection : FileRepositoryCollectionBase, ITranslatorRepositoryCollection
    {
        public TranslatorRepositoryCollection(string resourceDir, string extension, string encoding = "utf-8") : base(resourceDir, extension)
        {
            Comments = new CommentRepository(GetRepositoryPath("comment"), encoding);
        }

        public ICommentRepository Comments { get; }

    }
}
