using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Models
{
    internal class WriteConsoleCommand : ICommand<IBomRepository, DomainResponse>
    {
        public DomainResponse Invoke(IBomRepository repository, string[] args)
        {
            return DomainResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
