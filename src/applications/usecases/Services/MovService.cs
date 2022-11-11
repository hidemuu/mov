using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models;
using Mov.Configurator.Models;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Framework;
using Mov.Game.Models;

namespace Mov.UseCases.Services
{
    public class MovService : IMovService
    {
        public IAnalizerService Analizer { get; }
        public IConfiguratorService Configurator { get; }
        public IDesignerService Designer { get; }
        public IDriverService Driver { get; }
        public IGameService Game { get; }

        public MovService(
            IAnalizerService analizerService, IConfiguratorService configuratorService,
            IDesignerService designerService, IDriverService driverService,
            IGameService gameService)
        {
            this.Analizer = analizerService;
            this.Configurator = configuratorService;
            this.Designer = designerService;
            this.Driver = driverService;
            this.Game = gameService;
        }
    }
}
