using Mov.Core.Templates.Crud;

namespace Mov.Core.Repositories.Cruds
{
    public interface IPersistenceQuery<TEntity>
    {
        IRead<TEntity> Reader { get; }


    }
}
