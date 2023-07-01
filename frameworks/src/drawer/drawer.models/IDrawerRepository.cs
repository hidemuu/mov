using Mov.Core.Templates.Repositories;

namespace Mov.Drawer.Models
{
    public interface IDrawerRepository : IDomainRepository
    {
        IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }
    }
}