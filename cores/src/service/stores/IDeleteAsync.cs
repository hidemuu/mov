using System.Threading.Tasks;

namespace Mov.Core.Stores
{
    public interface IDeleteAsync<TEntity>
    {
        Task Delete(TEntity entity);
    }
}
