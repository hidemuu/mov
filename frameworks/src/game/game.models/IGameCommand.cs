using Mov.Core.Stores;
using Mov.Game.Models.Schemas;

namespace Mov.Game.Models
{
    public interface IGameCommand
    {
        IStoreCommand<LandmarkSchema> Landmark { get; }
    }
}