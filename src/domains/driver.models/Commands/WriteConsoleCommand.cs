using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    internal class WriteConsoleCommand : ICommand<IDriverRepository, DomainResponse>
    {
        public DomainResponse Invoke(IDriverRepository repository, string[] args)
        {
            Console.WriteLine(repository.Commands.ToString());
            return DomainResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
