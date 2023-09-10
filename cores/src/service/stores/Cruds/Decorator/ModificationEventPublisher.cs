using Mov.Core.Stores.Cruds;
using Mov.Core.Templates.Events;
using Mov.Core.Templates.Events.Implements;

namespace Mov.Core.Functions.Cruds.Decorator
{
    public class ModificationEventPublisher<T> : IDelete<T>, ISave<T>
    {
        private readonly IDelete<T> deleter;
        private readonly ISave<T> saver;
        private readonly IEventPublisher eventPublisher;

        public ModificationEventPublisher(IDelete<T> deleter, ISave<T> saver, IEventPublisher eventPublisher)
        {
            this.deleter = deleter;
            this.saver = saver;
            this.eventPublisher = eventPublisher;
        }

        public void Delete(T entity)
        {
            deleter.Delete(entity);
            var entityDeleted = new DeletedEvent<T>(entity);
            eventPublisher.Publish(entityDeleted);
        }

        public void Save(T entity)
        {
            saver.Save(entity);
            var entitySaved = new SavedEvent<T>(entity);
            eventPublisher.Publish(entitySaved);
        }
    }
}