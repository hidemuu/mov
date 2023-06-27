using Mov.Accessors;
using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Framework;
using Mov.Game.Models;
using Mov.UseCases.Factories;

namespace Mov.UseCases.Repositories
{
    public class FileMovRepository : IMovRepository
    {
        public IAnalizerRepository Analizer { get; }
        public IDesignerRepository Designer { get; }
        public IGameRepository Game { get; }

        public FileMovRepository(string endpoint)
        {
            var fileRepositoryFactory = new FileDomainRepositoryCollectionFactory(endpoint);
            this.Designer = fileRepositoryFactory.Create<IDesignerRepository>(AccessConstants.PATH_XML)?.GetDefaultRepository();
            this.Game = fileRepositoryFactory.Create<IGameRepository>(AccessConstants.PATH_JSON)?.GetDefaultRepository();
            this.Analizer = fileRepositoryFactory.Create<IAnalizerRepository>(AccessConstants.PATH_JSON)?.GetDefaultRepository();
        }
    }
}