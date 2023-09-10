using Mov.Core.Stores.Events;
using Mov.Core.Stores.Events.Implements;

namespace Mov.Core.Stores.Cruds.Decorator
{
    public class DeleteEventPublisher<T> : IDelete<T>
    {
        private readonly IDelete<T> decoratedDelete;
        private readonly IEventPublisher eventPublisher;

        public DeleteEventPublisher(IDelete<T> decoratedDelete, IEventPublisher eventPublisher)
        {
            this.decoratedDelete = decoratedDelete; ;
            this.eventPublisher = eventPublisher;
        }

        public void Delete(T entity)
        {
            decoratedDelete.Delete(entity);
            var entityDeleted = new DeletedEvent<T>(entity);
            eventPublisher.Publish(entityDeleted);
        }
    }
}
