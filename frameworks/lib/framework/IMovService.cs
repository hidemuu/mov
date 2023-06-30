using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Game.Engine;

namespace Mov.Framework
{
    public interface IMovService
    {
        IAnalizerFacade Analizer { get; }
        IDesignerFacade Designer { get; }
        IGameFacade Game { get; }
    }
}