using Mov.Accessors;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Repository
{
    public class CommentRepository : FileRepositoryBase<Comment, CommentCollection>, ICommentRepository
    {
        public CommentRepository(string path, string encoding = "utf-8") : base(path, encoding) { }
    }
}
