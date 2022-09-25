using Mov.Controllers.Service;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Service
{
    public class TranslatorService : DomainService<ITranslatorRepository>
    {
        public TranslatorService(ITranslatorRepository repository) : base(repository, new TranslatorCommandFactory())
        {
        }
    }
}
