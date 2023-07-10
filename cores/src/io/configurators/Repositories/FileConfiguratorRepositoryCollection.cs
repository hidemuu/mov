using Mov.Core.Repositories.Repositories.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Repositories
{
    public class FileConfiguratorRepositoryCollection
        : FileDomainRepositoryCollection<FileConfiguratorRepository, FileConfiguratorRepository>
    {
        public FileConfiguratorRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {
        }
    }
}
