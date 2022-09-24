using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Models;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Framework
{
    internal class WriteConsoleCommand : ICommand<IDomainRepository, DomainResponse>
    {
        public DomainResponse Invoke(IDomainRepository repository, string[] args)
        {
            if(repository is IConfiguratorRepository configrator)
            {
                Console.WriteLine(configrator.Configs.ToString());
            }
            else if (repository is IDesignerRepository designer)
            {
                Console.WriteLine(designer.Nodes.ToString());
            }
            else if (repository is IGameRepository game)
            {
                Console.WriteLine(game.Landmarks.ToString());
            }
            else if (repository is IDriverRepository driver)
            {
                Console.WriteLine(driver.Commands.ToString());
            }
            else
            {
                return DomainResponse.Error;
            }
            return DomainResponse.Success;
        }
    }
}
