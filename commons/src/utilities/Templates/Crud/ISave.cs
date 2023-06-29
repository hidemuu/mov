namespace Mov.Core.Templates.Crud
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
