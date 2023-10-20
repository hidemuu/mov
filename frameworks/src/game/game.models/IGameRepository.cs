using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Game.Models.Schemas;
using System;

namespace Mov.Game.Models
{
    public interface IGameRepository
    {
        IDbRepository<LandmarkSchema, Guid, DbRequestSchemaString> Landmarks { get; }
    }
}