using Mov.Core.Repositories;
using Mov.Drawer.Models.Entities;
using System;

namespace Mov.Drawer.Models
{
    public interface IDrawerRepository
    {
        IDbRepository<DrawItem, Guid> DrawItems { get; }
    }
}