using System.Threading.Tasks;

namespace Mov.Core.Templates.Crud
{
    public interface ISaveAsync<TEntity>
    {
        Task Save(TEntity entity);
    }
}
