using Mov.Accessors;
using Mov.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IDriverRepository
    {
        IDbObjectRepository<Error> Errors { get; }

        IDbObjectRepository<Macro> Macros { get; }

        IDbObjectRepository<Command> Commands { get; }

        IDbObjectRepository<Query> Queries { get; }

        IDbObjectRepository<Variable> Variables { get; }

        IDbObjectRepository<Schema> Schemas { get; }

        IDbObjectRepository<Connect> Connects { get; }
    }
}
