using Mov.Analizer.Engine;
using Mov.Designer.Engine;
using Mov.Framework;
using Mov.Game.Engine;

namespace Mov.UseCase.Services
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
            Analizer = analizerService;
            Designer = designerService;
            Game = gameService;
        }
    }
}