using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Framework;
using Mov.Game.Engine;

namespace Mov.UseCases.Services
{
    public class MovService : IMovService
    {
        public IAnalizerFacade Analizer { get; }
        public IDesignerFacade Designer { get; }
        public IGameFacade Game { get; }

        public MovService(
            IAnalizerFacade analizerService,
            IDesignerFacade designerService,
            IGameFacade gameService)
        {
            this.Analizer = analizerService;
            this.Designer = designerService;
            this.Game = gameService;
        }
    }
}
