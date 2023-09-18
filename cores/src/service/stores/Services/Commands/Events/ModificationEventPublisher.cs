using Mov.Core.Stores.Services.Commands.Deleters.Events;
using Mov.Core.Stores.Services.Commands.Savers.Events;

namespace Mov.Core.Stores.Services.Commands.Events
{
    public class ModificationEventPublisher<TEntity> : IDelete<TEntity>, ISave<TEntity>
    {
        private readonly IDelete<TEntity> deleter;
        private readonly ISave<TEntity> saver;
        private readonly IEventPublisher eventPublisher;

        public ModificationEventPublisher(IDelete<TEntity> deleter, ISave<TEntity> saver, IEventPublisher eventPublisher)
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