using Mov.Core.Stores.Services.Deleters.Events;
using Mov.Core.Stores.Services.Savers.Events;

namespace Mov.Core.Stores.Services
{
    public class ModificationEventPublisher<TEntity, TKey> : IDelete<TEntity, TKey>, ISave<TEntity>
    {
        private readonly IDelete<TEntity, TKey> deleter;
        private readonly ISave<TEntity> saver;
        private readonly IEventPublisher eventPublisher;

        public ModificationEventPublisher(IDelete<TEntity, TKey> deleter, ISave<TEntity> saver, IEventPublisher eventPublisher)
        {
            this.deleter = deleter;
            this.saver = saver;
            this.eventPublisher = eventPublisher;
        }

        public void Delete(TEntity entity)
        {
            deleter.Delete(entity);
            var entityDeleted = new DeletedEvent<TEntity>(entity);
            eventPublisher.Publish(entityDeleted);
        }

        public void Save(TEntity entity)
        {
            saver.Save(entity);
            var entitySaved = new SavedEvent<TEntity>(entity);
            eventPublisher.Publish(entitySaved);
        }
    }
}