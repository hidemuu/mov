using Mov.Accessors;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IDriverRepository
    {
        IDbObjectRepository<Error, ErrorCollection> Errors { get; }

        IDbObjectRepository<Macro, MacroCollection> Macros { get; }

        IDbObjectRepository<Command, CommandCollection> Commands { get; }

        IDbObjectRepository<Query, QueryCollection> Queries { get; }

        IDbObjectRepository<Variable, VariableCollection> Variables { get; }

        IDbObjectRepository<Schema, SchemaCollection> Schemas { get; }

        IDbObjectRepository<Connect, ConnectCollection> Connects { get; }
    }
}
