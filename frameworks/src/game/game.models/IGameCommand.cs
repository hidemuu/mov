using Mov.Core.Templates.Crud;
using Mov.Game.Models.Entities.Schemas;

namespace Mov.Game.Models
{
    public interface IGameCommand
    {
        IPersistenceCommand<Landmark> Landmark { get; }
    }
}