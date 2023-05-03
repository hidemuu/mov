using Mov.Accessors.Repository.Implement;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Repository.File
{
    public class FileConfiguratorRepositoryCollection
        : FileDomainRepositoryCollection<FileConfiguratorRepository, FileConfiguratorRepository>, IConfiguratorRepositoryCollection
    {
        public FileConfiguratorRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {

        }
    }
}
