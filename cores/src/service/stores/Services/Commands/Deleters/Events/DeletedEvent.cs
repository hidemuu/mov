﻿namespace Mov.Core.Stores.Services.Commands.Deleters.Events
{
    public class DeletedEvent<TEntity> : IEvent
    {
        public string Name { get; } = "EntityDeleted";

        public TEntity Entity { get; set; }

        public DeletedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}
