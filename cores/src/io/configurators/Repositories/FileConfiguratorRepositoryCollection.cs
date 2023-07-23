using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Repositories.Domains;

namespace Mov.Core.Configurators.Repositories
{
    public class FileConfiguratorRepositoryCollection
        : FileDomainRepositoryCollection<FileConfiguratorRepository, FileConfiguratorRepository>
    {
        public FileConfiguratorRepositoryCollection(string endpoint, FileType fileType) : base(endpoint, fileType, EncodingValue.UTF8)
        {
        }
    }
}
