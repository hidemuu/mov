using Mov.Core.Templates.Repositories;
using Mov.Drawer.Models.Entities;

namespace Mov.Drawer.Models
{
    public interface IDrawerRepository : IDomainRepository
    {
        IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }
    }
}