using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Models
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> Gets();
    }
}
