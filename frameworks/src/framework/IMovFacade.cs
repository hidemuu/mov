using Mov.Analizer.Service;
using Mov.Designer.Service;
using Mov.Game.Service;

namespace Mov.Framework
{
    public interface IMovFacade
    {
        IAnalizerFacade Analizer { get; }
        IDesignerFacade Designer { get; }
        IGameFacade Game { get; }
    }
}