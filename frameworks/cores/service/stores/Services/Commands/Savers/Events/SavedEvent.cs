namespace Mov.Core.Stores.Services.Commands.Savers.Events
{
    public class SavedEvent<TEntity> : IEvent
    {
        public string Name { get; } = "EntitySaved";

        public TEntity Entity { get; set; }

        public SavedEvent(TEntity entity)
        {
            Entity = entity;
        }

    }
}

