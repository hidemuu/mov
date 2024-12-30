using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Driver.Models.Schemas;
using System;

namespace Mov.Driver.Models
{
    public interface IDriverRepository
    {
        IDbRepository<VariableSchema, Guid, DbRequestSchemaString> Variables { get; }

        IDbRepository<ConnectSchema, Guid, DbRequestSchemaString> Connects { get; }
    }
}
