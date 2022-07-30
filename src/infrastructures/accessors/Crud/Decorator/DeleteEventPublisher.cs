using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Decorator
{
    public class DeleteEventPublisher<T> : IDelete<T>
    {
        private readonly IDelete<T> decoratedDelete;
        private readonly IEventPublisher eventPublisher;

        public DeleteEventPublisher(IDelete<T> decoratedDelete, IEventPublisher eventPublisher)
        {
            this.decoratedDelete = decoratedDelete;;
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
