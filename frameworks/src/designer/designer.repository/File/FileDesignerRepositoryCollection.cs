using Mov.Core.Repositories.Services.Repositories.Domains;
using Mov.Designer.Models;

namespace Mov.Designer.Repository.Implements
{
    public class FileDesignerRepositoryCollection
        : FileDomainRepositoryCollection<IDesignerRepository, FileDesignerRepository>, IDesignerRepositoryCollection
    {
        public FileDesignerRepositoryCollection(string endpoint, string extension) : base(endpoint, extension)
        {
        }
    }
}