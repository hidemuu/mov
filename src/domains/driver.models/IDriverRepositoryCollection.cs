using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IDriverRepositoryCollection
    {
        DbObjectRepository<Error, ErrorCollection> Errors { get; }

        DbObjectRepository<Macro, MacroCollection> Macros { get; }

        DbObjectRepository<Schema, SchemaCollection> Schemas { get; }

        DbObjectRepository<Variable, VariableCollection> Variables { get; }

        DbObjectRepository<Connect, ConnectCollection> Connects { get; }
    }
}
