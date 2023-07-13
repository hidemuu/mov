using Mov.Analizer.Models;
using Mov.Core.Configurators;
using Mov.Core.Translators;
using Mov.Designer.Models;
using Mov.Game.Models;

namespace Mov.Framework
{
    public interface IMovRepository
    {
        IAnalizerRepository Analizer { get; }
        IDesignerRepository Designer { get; }
        IGameRepository Game { get; }
        IConfiguratorRepository Configurator { get; }
        ITranslatorRepository Translator { get; }
    }
}