namespace Mov.Core.Stores.Events
{
    public class DeletedEvent<T> : IEvent
    {
        public string Name { get; } = "EntityDeleted";

        public T Entity { get; set; }

        public DeletedEvent(T entity)
        {
            Entity = entity;
        }
    }
}
