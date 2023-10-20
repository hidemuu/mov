using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Drawer.Models.Entities;
using System;

namespace Mov.Drawer.Models
{
    public interface IDrawerRepository
    {
        IDbRepository<DrawItem, Guid, DbRequestSchemaString> DrawItems { get; }
    }
}