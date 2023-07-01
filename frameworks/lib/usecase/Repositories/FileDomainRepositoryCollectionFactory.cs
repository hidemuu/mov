using Mov.Core.Repositories.Repositories.Domains;
using Mov.Core.Templates.Repositories;
using Mov.Designer.Models;
using Mov.Designer.Repository.File;
using Mov.Drawer.Models;
using Mov.Drawer.Repository;
using Mov.Game.Models;
using Mov.Game.Repository;

namespace Mov.UseCase.Repositories
{
    public class FileDomainRepositoryCollectionFactory
    {
        private readonly string resourcePath;

        public FileDomainRepositoryCollectionFactory(string resourcePath)
        {
            this.resourcePath = resourcePath;
        }

        public IDomainRepositoryCollection<TRepository> Create<TRepository>(string fileType) where TRepository : IDomainRepository
        {
            var repositoryType = typeof(TRepository);
            if (repositoryType == typeof(IDesignerRepository))
            {
                return new FileDomainRepositoryCollection<TRepository, FileDesignerRepository>(
                    resourcePath, fileType);
            }
            if (repositoryType == typeof(IDrawerRepository))
            {
                return new FileDomainRepositoryCollection<TRepository, FileDrawerRepository>(
                    resourcePath, fileType);
            }
            if (repositoryType == typeof(IGameRepository))
            {
                return new FileDomainRepositoryCollection<TRepository, FileGameRepository>(
                    resourcePath, fileType);
            }
            return null;
        }
    }
}