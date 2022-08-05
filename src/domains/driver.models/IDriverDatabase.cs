using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IDriverDatabase
    {
        IRepository<Error, ErrorCollection> Errors { get; }

        IRepository<Macro, MacroCollection> Macros { get; }

        IRepository<Variable, VariableCollection> Variables { get; }

        IRepository<Schema, SchemaCollection> Schemas { get; }

        IRepository<Connect, ConnectCollection> Connects { get; }
    }
}
