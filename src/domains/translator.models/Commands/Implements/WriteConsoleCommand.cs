using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Models
{
    internal class WriteConsoleCommand : ICommand<ITranslatorRepository, DomainResponse>
    {
        public DomainResponse Invoke(ITranslatorRepository repository, string[] args)
        {
            return DomainResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
