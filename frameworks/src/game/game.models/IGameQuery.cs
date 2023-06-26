using Mov.Game.Models.Entities.Schemas;
using Mov.Repositories.Services.Cruds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameQuery
    {
        IPersistenceQuery<Landmark> Landmark { get; }
    }
}
