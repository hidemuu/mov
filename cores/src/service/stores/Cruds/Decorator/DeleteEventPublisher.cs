using Mov.Core.Stores.Cruds;
using Mov.Core.Templates.Events;
using Mov.Core.Templates.Events.Implements;

namespace Mov.Core.Functions.Cruds.Decorator
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
