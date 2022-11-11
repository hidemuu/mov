using Mov.Accessors.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public class FileConfiguratorRepositoryCollection
        : FileDomainRepositoryCollection<FileConfiguratorRepository, FileConfiguratorRepository>
    {
        public FileConfiguratorRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {

        }
    }
}
