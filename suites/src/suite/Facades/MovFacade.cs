using Mov.Analizer.Service;
using Mov.Designer.Service;
using Mov.Framework;
using Mov.Game.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.Facades
{
    public class MovFacade : IMovFacade
    {
        public IAnalizerFacade Analizer { get; }
        public IDesignerFacade Designer { get; }
        public IGameFacade Game { get; }

        public MovFacade(
            IAnalizerFacade analizerService,
            IDesignerFacade designerService,
            IGameFacade gameService)
        {
            Analizer = analizerService;
            Designer = designerService;
            Game = gameService;
        }
    }
}
