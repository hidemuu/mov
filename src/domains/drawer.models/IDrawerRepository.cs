using Mov.Repositories.Services;

namespace Mov.Drawer.Models
{
    public interface IDrawerRepository : IDomainRepository
    {
        IDbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }
    }
}