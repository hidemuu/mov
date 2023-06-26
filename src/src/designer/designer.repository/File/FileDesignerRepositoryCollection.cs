using Mov.Designer.Models;
using Mov.Repositories.Services.Repositories.Domains;

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