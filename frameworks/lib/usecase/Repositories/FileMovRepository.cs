using Mov.Analizer.Models;
using Mov.Core.Accessors;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Translators;
using Mov.Core.Translators.Repositories;
using Mov.Designer.Models;
using Mov.Framework;
using Mov.Game.Models;

namespace Mov.UseCase.Repositories
{
    public class FileMovRepository : IMovRepository
    {
        public IAnalizerRepository Analizer { get; }
        public IDesignerRepository Designer { get; }
        public IGameRepository Game { get; }
        public IConfiguratorRepository Configurator { get; }
        public ITranslatorRepository Translator { get; }

        public FileMovRepository(string endpoint)
        {
            var fileRepositoryFactory = new FileDomainRepositoryCollectionFactory(endpoint);
            Designer = fileRepositoryFactory.Create<IDesignerRepository>(AccessConstants.PATH_XML)?.GetDefaultRepository();
            Game = fileRepositoryFactory.Create<IGameRepository>(AccessConstants.PATH_JSON)?.GetDefaultRepository();
            Analizer = fileRepositoryFactory.Create<IAnalizerRepository>(AccessConstants.PATH_JSON)?.GetDefaultRepository();
            Configurator = new FileConfiguratorRepository(endpoint, "", AccessConstants.PATH_JSON);
            Translator = new FileTranslatorRepository(endpoint);
        }
    }
}