using Mov.Analizer.Engine;
using Mov.Designer.Engine;
using Mov.Game.Engine;

namespace Mov.Framework
{
    public interface IMovFacade
    {
        IAnalizerFacade Analizer { get; }
        IDesignerFacade Designer { get; }
        IGameFacade Game { get; }
    }
}