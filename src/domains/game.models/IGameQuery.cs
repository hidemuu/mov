using Mov.Accessors;
using Mov.Controllers.Repository.Persistences;
using Mov.Game.Models.Entities.Schemas;
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
