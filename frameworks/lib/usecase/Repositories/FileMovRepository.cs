using Mov.Analizer.Models;
using Mov.Core.Accessors;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Models.Texts;
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
            Designer = fileRepositoryFactory.Create<IDesignerRepository>(FileType.Xml)?.GetDefaultRepository();
            Game = fileRepositoryFactory.Create<IGameRepository>(FileType.Json)?.GetDefaultRepository();
            Analizer = fileRepositoryFactory.Create<IAnalizerRepository>(FileType.Json)?.GetDefaultRepository();
            Configurator = new FileConfiguratorRepository(endpoint, FileType.Json, EncodingValue.UTF8);
            Translator = new FileTranslatorRepository(endpoint);
        }
    }
}