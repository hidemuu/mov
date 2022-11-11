using Mov.Accessors.Repository.Implement;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository.Implements
{
    public class FileConfiguratorRepositoryCollection
        : FileDomainRepositoryCollection<IConfiguratorRepository, FileConfiguratorRepository>
    {
        public FileConfiguratorRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {

        }
    }
}
