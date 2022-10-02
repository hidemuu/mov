using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models
{
    internal class WriteConsoleCommand : ICommand<IAnalizerRepository, DomainResponse>
    {
        public DomainResponse Invoke(IAnalizerRepository repository, string[] args)
        {
            return DomainResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
