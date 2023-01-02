using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models;
using Mov.Designer.Models.Services;
using Mov.Driver.Models;
using Mov.Framework;
using Mov.Game.Models;

namespace Mov.UseCases.Services
{
    public class MovService : IMovService
    {
        public IAnalizerService Analizer { get; }
        public IDesignerFacade Designer { get; }
        public IDriverService Driver { get; }
        public IGameService Game { get; }

        public MovService(
            IAnalizerService analizerService,
            IDesignerFacade designerService, IDriverService driverService,
            IGameService gameService)
        {
            this.Analizer = analizerService;
            this.Designer = designerService;
            this.Driver = driverService;
            this.Game = gameService;
        }
    }
}
