using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    internal class WriteConsoleCommand : ICommand<IConfiguratorRepository, DomainResponse>
    {
        public DomainResponse Invoke(IConfiguratorRepository repository, string[] args)
        {
            Console.WriteLine(repository.UserSettings.ToString());
            Console.WriteLine(repository.Errors.ToString());
            Console.WriteLine(repository.Schemas.ToString());
            return DomainResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
