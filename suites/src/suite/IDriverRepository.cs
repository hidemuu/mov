﻿using Mov.Core.Templates.Repositories;
using Mov.Driver.Models.Entities.Schemas;

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