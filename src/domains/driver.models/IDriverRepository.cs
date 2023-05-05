using Mov.Accessors.Repository.Domain;
using Mov.Driver.Models.Entities.Schemas;
using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

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
