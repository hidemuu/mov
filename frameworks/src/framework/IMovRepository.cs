using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Game.Models;

namespace Mov.Framework
{
    public interface IMovRepository
    {
        IAnalizerRepository Analizer { get; }
        IDesignerRepository Designer { get; }
        IGameRepository Game { get; }
    }
}