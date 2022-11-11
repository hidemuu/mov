using Mov.Analizer.Models;
using Mov.Configurator.Models;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Framework
{
    public interface IMovService
    {
        IAnalizerService Analizer { get; }
        IConfiguratorService Configurator { get; }
        IDesignerService Designer { get; }
        IDriverService Driver { get; }
        IGameService Game { get; }
    }
}
