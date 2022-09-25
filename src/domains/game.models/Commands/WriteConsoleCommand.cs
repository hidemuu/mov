using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Game.Models;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    internal class WriteConsoleCommand : ICommand<IGameRepository, DomainResponse>
    {
        public DomainResponse Invoke(IGameRepository repository, string[] args)
        {
            Console.WriteLine(repository.Landmarks.ToString());
            return DomainResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
