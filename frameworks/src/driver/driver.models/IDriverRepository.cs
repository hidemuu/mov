﻿using Mov.Driver.Models.Entities.Schemas;
using Mov.Repositories.Services;

namespace Mov.Driver.Models
{
    public interface IDriverRepository : IDomainRepository
    {
        IDbObjectRepository<Macro, MacroCollection> Macros { get; }

        IDbObjectRepository<Command, CommandCollection> Commands { get; }

        IDbObjectRepository<Query, QueryCollection> Queries { get; }

        IDbObjectRepository<Variable, VariableCollection> Variables { get; }

        IDbObjectRepository<Connect, ConnectCollection> Connects { get; }
    }
}