using Mov.Core.Stores.Events;

namespace Mov.Core.Stores.Cruds.Decorator
{
    public class DeleteEventPublisher<TEntity, TKey> : IDelete<TEntity, TKey>
    {
        private readonly IDelete<TEntity, TKey> decoratedDelete;
        private readonly IEventPublisher eventPublisher;

        public DeleteEventPublisher(IDelete<TEntity, TKey> decoratedDelete, IEventPublisher eventPublisher)
        {
            this.decoratedDelete = decoratedDelete; ;
            this.eventPublisher = eventPublisher;
        }

        public void Delete(TEntity entity)
        {
            decoratedDelete.Delete(entity);
            var entityDeleted = new DeletedEvent<TEntity>(entity);
            eventPublisher.Publish(entityDeleted);
        }
    }
}
