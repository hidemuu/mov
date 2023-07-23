using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Repositories.Domains;
using Mov.Designer.Models;

namespace Mov.Designer.Repository.File
{
    public class FileDesignerRepositoryCollection
        : FileDomainRepositoryCollection<IDesignerRepository, FileDesignerRepository>, IDesignerRepositoryCollection
    {
        public FileDesignerRepositoryCollection(string endpoint, FileType fileType) : base(endpoint, fileType, EncodingValue.UTF8)
        {
        }
    }
}