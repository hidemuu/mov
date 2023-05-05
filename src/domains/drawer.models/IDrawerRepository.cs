using Mov.Accessors.Repository.Domain;
using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Models
{
    public interface IDrawerRepository : IDomainRepository
    {
        IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }
    }
}
