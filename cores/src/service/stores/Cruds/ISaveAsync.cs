using System.Threading.Tasks;

namespace Mov.Core.Stores.Cruds
{
    public interface ISaveAsync<TEntity>
    {
        Task Save(TEntity entity);
    }
}
