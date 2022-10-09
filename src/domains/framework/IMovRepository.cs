using Mov.Analizer.Models;
using Mov.Configurator.Models;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Models;
using Mov.Translator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Framework
{
    public interface IMovRepository
    {
        IAnalizerRepository Analizer { get; }
        IConfiguratorRepository Configurator { get; }
        IDesignerRepository Designer { get; }
        IDriverRepository Driver { get; }
        IGameRepository Game { get; }
        ITranslatorRepository Translator { get; }
    }
}
