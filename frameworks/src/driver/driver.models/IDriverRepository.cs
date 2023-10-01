using Mov.Core.Repositories;
using Mov.Driver.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IDriverRepository
    {
        IDbRepository<VariableSchema, Guid> Variables { get; }

        IDbRepository<ConnectSchema, Guid> Connects { get; }
    }
}
