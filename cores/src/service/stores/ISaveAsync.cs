using System.Threading.Tasks;

namespace Mov.Core.Stores
{
    public interface ISaveAsync<TEntity>
    {
        Task Save(TEntity entity);
    }
}
