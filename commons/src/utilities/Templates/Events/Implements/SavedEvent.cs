using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Events.Implements
{
    public class SavedEvent<T> : IEvent
    {
        public string Name { get; } = "EntitySaved";

        public T Entity { get; set; }

        public SavedEvent(T entity)
        {
            Entity = entity;
        }

    }
}

