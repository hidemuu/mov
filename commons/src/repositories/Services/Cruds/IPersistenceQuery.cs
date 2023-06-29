using Mov.Core.Templates.Crud;

namespace Mov.Core.Repositories.Services.Cruds
{
    public interface IPersistenceQuery<TEntity>
    {
        IRead<TEntity> Reader { get; }


    }
}
