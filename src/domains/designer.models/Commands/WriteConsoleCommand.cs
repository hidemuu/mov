using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    internal class WriteConsoleCommand : ICommand<IDesignerRepository, DomainResponse>
    {
        public DomainResponse Invoke(IDesignerRepository repository, string[] args)
        {
            Console.WriteLine(repository.Nodes.ToString());
            return DomainResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
