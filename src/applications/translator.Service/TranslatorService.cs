using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Service
{
    public class TranslatorService
    {
        private readonly ITranslatorRepository repository;

        public TranslatorService(ITranslatorRepository repository)
        {
            this.repository = repository;
        }
    }
}
