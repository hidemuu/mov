using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepositoryCollection
    {
        IDictionary<string, IConfiguratorRepository> Repositories { get; }

        IConfiguratorRepository GetRepository(string dirName);
    }
}
