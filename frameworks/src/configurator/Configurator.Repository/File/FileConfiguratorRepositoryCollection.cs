using Mov.Core.Repositories.Repositories.Domains;

namespace Mov.Configurator.Repository.File
{
    public class FileConfiguratorRepositoryCollection
        : FileDomainRepositoryCollection<FileConfiguratorRepository, FileConfiguratorRepository>
    {
        public FileConfiguratorRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {
        }
    }
}