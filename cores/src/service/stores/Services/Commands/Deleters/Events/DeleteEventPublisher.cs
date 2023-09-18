namespace Mov.Core.Stores.Services.Commands.Deleters.Events
{
    public class DeleteEventPublisher<TEntity> : IDelete<TEntity>
    {
        private readonly IDelete<TEntity> decoratedDelete;
        private readonly IEventPublisher eventPublisher;

        public DeleteEventPublisher(IDelete<TEntity> decoratedDelete, IEventPublisher eventPublisher)
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
