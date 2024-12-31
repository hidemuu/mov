using Mov.Analizer.Models;
using Mov.Analizer.Repository.Files;
using Mov.Core.Accessors.Models;
using Mov.Core.Configurators;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Translators;
using Mov.Core.Translators.Repositories;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Framework;
using Mov.Game.Models;
using Mov.Game.Repository;

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
            Designer = new FileDesignerRepository(endpoint, FileType.Xml, EncodingValue.UTF8);
            Game = new FileGameRepository(endpoint, FileType.Json, EncodingValue.UTF8);
            Analizer = new FileAnalizerRepository();
            Configurator = new FileConfiguratorRepository(endpoint, FileType.Json, EncodingValue.UTF8);
            Translator = new FileTranslatorRepository(endpoint);
        }
    }
}