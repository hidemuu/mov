using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Events.Implements
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
