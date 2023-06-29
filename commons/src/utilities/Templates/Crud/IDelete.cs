namespace Mov.Core.Templates.Crud
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
    }
}
