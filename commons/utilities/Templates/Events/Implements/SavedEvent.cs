using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
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

