using Mov.Core.Repositories.Services.Repositories.Domains;

namespace Configurator.Repository.File
{
    public class FileConfiguratorRepositoryCollection
        : FileDomainRepositoryCollection<FileConfiguratorRepository, FileConfiguratorRepository>
    {
        public FileConfiguratorRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {
        }
    }
}