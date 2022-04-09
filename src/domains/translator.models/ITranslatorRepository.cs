using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Models
{
    public interface ITranslatorRepository
    {
        ICommentRepository Comments { get; }
    }
}
