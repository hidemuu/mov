using Mov.Controllers;
using Mov.Controllers.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Models
{
    public class TranslatorCommandFactory : ICommandFactory<ITranslatorRepository, DomainResponse>
    {
        public IDictionary<string, ICommand<ITranslatorRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<ITranslatorRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}
