using System.Threading.Tasks;

namespace Mov.Core.Templates.Crud
{
    public interface IDeleteAsync<TEntity>
    {
        Task Delete(TEntity entity);
    }
}
