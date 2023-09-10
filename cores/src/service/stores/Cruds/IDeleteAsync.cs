using System.Threading.Tasks;

namespace Mov.Core.Stores.Cruds
{
    public interface IDeleteAsync<TEntity>
    {
        Task Delete(TEntity entity);
    }
}
