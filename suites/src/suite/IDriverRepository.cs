using Mov.Core.Repositories;
using Mov.Driver.Models.Entities.Schemas;
using System;

namespace Mov.Driver.Models
{
    public interface IDriverRepository
    {
        IDbRepository<Macro, Guid> Macros { get; }

        IDbRepository<Command, Guid> Commands { get; }

        IDbRepository<Query, Guid> Queries { get; }

        IDbRepository<Variable, Guid> Variables { get; }

        IDbRepository<Connect, Guid> Connects { get; }
    }
}